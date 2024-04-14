using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;
    public char up;
    public char down;
    public char right;
    public char left;

    private float _movementSpeed = 5.0f;

    [DontCreateProperty]
    public bool CanMove;

    void Start()
    {
        if (up != 'w')
        {
            up = (char)38;
            down = (char)40;
            left = (char)37;
            right = (char)39;
        }
    }

    private void ArrowMovement()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            direction = Vector3.forward;
        if (Input.GetKey(KeyCode.DownArrow))
            direction = Vector3.back;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector3.right;
        if (Input.GetKey(KeyCode.Space))
            direction = Vector3.up;

        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }
    private void KeysMovement()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            direction = Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            direction = Vector3.back;
        if (Input.GetKey(KeyCode.A))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction = Vector3.right;
        if (Input.GetKey(KeyCode.Z))
            direction = Vector3.up;

        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }
    void Update()
    {
        if (CanMove)
        {
            if (up == 38)
                ArrowMovement();
            else
                KeysMovement();
        }
    }
}
