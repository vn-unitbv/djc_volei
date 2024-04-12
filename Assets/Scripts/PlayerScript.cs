using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public char up;
    public char down;
    public char right;
    public char left;
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

    // Update is called once per frame

    private void ArrowMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            Player.transform.Translate(-0.05f, 0, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            Player.transform.Translate(0.05f, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            Player.transform.Translate(0, 0, -0.05f);
        if (Input.GetKey(KeyCode.RightArrow))
            Player.transform.Translate(0, 0, 0.05f);
        if (Input.GetKey(KeyCode.Space))
            Player.transform.Translate(0, 0.2f, 0);
    }
    private void KeysMovement()
    {
        if (Input.GetKey(KeyCode.W))
            Player.transform.Translate(0.05f, 0, 0);
        if (Input.GetKey(KeyCode.S))
            Player.transform.Translate(-0.05f, 0, 0);
        if (Input.GetKey(KeyCode.A))
            Player.transform.Translate(0, 0, 0.05f);
        if (Input.GetKey(KeyCode.D))
            Player.transform.Translate(0, 0, -0.05f);
        if (Input.GetKey(KeyCode.Z))
            Player.transform.Translate(0, 0.2f, 0);
    }
    void Update()
    {
        if (up == 38)
            ArrowMovement();
        else
            KeysMovement();
    }
}
