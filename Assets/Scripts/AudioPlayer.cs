using UnityEngine;
using Random = System.Random;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource Referee;
    public AudioSource Ball;
    public AudioClip[] BallHit;
    public AudioClip[] BallSand;

    private Random _random = new Random();

    public void PlayRefereeWhistle()
    {
        Referee.Play();
    }

    public void PlayBallHit()
    {
        int index = _random.Next(BallHit.Length);
        Ball.clip = BallHit[index];
        Ball.Play();
    }

    public void PlayBallSand()
    {
        int index = _random.Next(BallSand.Length);
        Ball.clip = BallSand[index];
        Ball.Play();
    }
}