using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball;
    public Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (Random.Range(1.0f, 2.0f) > 1.4f)
            body.AddForce(new(0, 0, 1), ForceMode.Impulse);
        else
            body.AddForce(new(0,0,-1),ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player 1"))
            body.AddForce(Random.RandomRange(10,50), 750, Random.RandomRange(10,50));
        else if (collision.gameObject.tag.Equals("Player 2"))
            body.AddForce(Random.RandomRange(10, 50),750, Random.RandomRange(10, 50));
    }
}
