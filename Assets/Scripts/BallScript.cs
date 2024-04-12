using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball;
    public Rigidbody body;
    public int player1Points;
    public int player2Points;
    public TMP_Text Score1;
    public TMP_Text Score2;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (Random.Range(1.0f, 2.0f) > 1.4f)
            body.AddForce(new(0, 0, 2.5f), ForceMode.Impulse);
        else
            body.AddForce(new(0, 0, -2.5f), ForceMode.Impulse);
        player1Points = player2Points = 0;
        Score1 = GameObject.FindGameObjectWithTag("score 1").GetComponentInChildren<TMP_Text>();
        Score2 = GameObject.FindGameObjectWithTag("score 2").GetComponentInChildren<TMP_Text>();
        Score1.text += (" " + 0);
        Score2.text += (" " + 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player 1"))
            body.AddForce(Random.Range(-0.5f, 0.5f), 4, 0.9f, ForceMode.Impulse);
        else if (collision.gameObject.tag.Equals("Player 2"))
            body.AddForce(Random.Range(-0.5f, 0.5f), 4, -0.9f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("side 1"))
            Score1.text = "Score: " + (++player1Points).ToString();
        else if (other.gameObject.tag.Equals("side 2"))
            Score2.text = "Score: " + (++player2Points).ToString();
        else if (other.gameObject.tag.Equals("Plane") || other.gameObject.tag.Equals("court"))
            SceneManager.LoadSceneAsync(1);
    }
}
