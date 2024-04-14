using UnityEngine;
using Random = System.Random;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource Referee;
    public AudioSource Ball;
    public AudioClip[] BallHit;

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
}