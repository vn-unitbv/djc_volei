using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

public class BallScript : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public event Action<int> SideHit;
    public event Action OutsideHit;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TempInitialLaunch()
    {
        _rigidbody.velocity = Vector3.zero;
        transform.localPosition = new Vector3(0.0f, 14.0f, 0.0f);
        if (Random.Range(1.0f, 2.0f) > 1.4f)
            _rigidbody.AddForce(new(0, 0, 2.5f), ForceMode.Impulse);
        else
            _rigidbody.AddForce(new(0, 0, -2.5f), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player 1"))
        {
            _rigidbody.AddForce(Random.Range(-0.5f, 0.5f), 4, -0.9f, ForceMode.Impulse);
        }
        else if (collision.gameObject.tag.Equals("Player 2"))
        {
            _rigidbody.AddForce(Random.Range(-0.5f, 0.5f), 4, 0.9f, ForceMode.Impulse);
        }
        else if (collision.gameObject.tag.Equals("court"))
        {
            OutsideHit?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("side 1"))
        {
            SideHit?.Invoke(1);
        }
        else if (other.gameObject.tag.Equals("side 2"))
        {
            SideHit?.Invoke(2);
        }
    }
}
