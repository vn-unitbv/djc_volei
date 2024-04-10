using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball;
    public Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (Random.Range(1.0f, 2.0f) > 1.4f)
            body.AddForce(new(0, 0, 2.5f), ForceMode.Impulse);
        else
            body.AddForce(new(0,0,-2.5f),ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player 1"))
            body.AddForce(Random.Range(-0.5f, 0.5f), 4, 0.7f, ForceMode.Impulse);
        else if (collision.gameObject.tag.Equals("Player 2"))
            body.AddForce(Random.Range(-0.5f, 0.5f), 4,-0.7f, ForceMode.Impulse);
        else if(collision.gameObject.tag.Equals("Plane"))
            SceneManager.LoadSceneAsync(1);
    }
}
