using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class BallScript : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public event Action<int> SideHit;
    public event Action OutsideHit;
    public event Action<int> PlayerHit;
    public event Action GroundHit;

    public float Gravity = 9.81f;

    private enum HitState
    {
        None, Inside, Outside
    }

    private HitState _hitState = HitState.None;
    private int _hitSide;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 gravity = Gravity * Vector3.down;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);

        switch (_hitState)
        {
            case HitState.None:
                break;
            case HitState.Inside:
                _hitState = HitState.None;
                SideHit?.Invoke(_hitSide);
                break;
            case HitState.Outside:
                _hitState = HitState.None;
                OutsideHit?.Invoke();
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player 1"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Random.Range(-0.5f, 0.5f), 8, -3f, ForceMode.VelocityChange);
            PlayerHit?.Invoke(1);
        }
        else if (collision.gameObject.tag.Equals("Player 2"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Random.Range(-0.5f, 0.5f), 8, 3f, ForceMode.VelocityChange);
            PlayerHit?.Invoke(2);
        }
        else if (collision.gameObject.tag.Equals("court"))
        {
            if (_hitState == HitState.None)
            {
                _hitState = HitState.Outside;
            }
            if(collision.collider?.material.name == "SandPhysicMaterial (Instance)")
            {
                GroundHit?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("side 1"))
        {
            _hitSide = 1;
            _hitState = HitState.Inside;
        }
        else if (other.gameObject.tag.Equals("side 2"))
        {
            _hitSide = 2;
            _hitState = HitState.Inside;
        }
    }
}
