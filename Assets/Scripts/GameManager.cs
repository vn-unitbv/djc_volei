using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _Player1;
    [SerializeField]
    private GameObject _Player2;
    [SerializeField]
    private GameObject _Ball;

    [SerializeField]
    private ScoreDisplay _ScoreDisplay;

    [SerializeField]
    private AudioPlayer _AudioPlayer;

    private BallScript _ballLogic;
    private PlayerScript _player1Logic;
    private PlayerScript _player2Logic;

    private int _player1Score = 0;
    private int _player2Score = 0;

    public enum State
    {
        Serve, Play, Score, Finish
    }
    private State _state;
    private int _servingPlayer = 1;

    private void Awake()
    {
        _ballLogic = _Ball.GetComponent<BallScript>();
        _ballLogic.SideHit += BallLogic_SideHit;
        _ballLogic.OutsideHit += BallLogic_OutsideHit;
        _ballLogic.PlayerHit += BallLogic_PlayerHit;

        _player1Logic = _Player1.GetComponent<PlayerScript>();
        _player2Logic = _Player2.GetComponent<PlayerScript>();

    }

    void Start()
    {
        StartCoroutine(SetupNewServe());
    }

    void Update()
    {

    }

    private IEnumerator SetupNewServe()
    {
        _state = State.Serve;

        _Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _Ball.GetComponent<Rigidbody>().isKinematic = true;
        _player1Logic.CanMove = false;
        _player2Logic.CanMove = false;
        _Player1.transform.localPosition = new Vector3(0.0f, 2.14f, 8.67f);
        _Player2.transform.localPosition = new Vector3(0.0f, 2.14f, -8.67f);
        if (_servingPlayer == 1)
        {
            _Ball.transform.localPosition = new Vector3(0.0f, 2.856f, 7.0f);
        }
        else
        {
            _Ball.transform.localPosition = new Vector3(0.0f, 2.856f, -7.0f);
        }

        yield return new WaitForSeconds(2);

        _state = State.Play;
        _player1Logic.CanMove = true;
        _player2Logic.CanMove = true;
        _Ball.GetComponent<Rigidbody>().isKinematic = false;
        if (_servingPlayer == 1)
            _Ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 14.0f, -7.0f), ForceMode.VelocityChange);
        else
            _Ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 14.0f, 7.0f), ForceMode.VelocityChange);
    }

    private void BallLogic_SideHit(int side)
    {
        StartCoroutine(HandleSideHit(side));
    }

    private void BallLogic_PlayerHit(int player)
    {
        if ( _state == State.Play)
        {
            _AudioPlayer.PlayBallHit(); 
        }
    }

    private IEnumerator HandleSideHit(int side)
    {
        if (_state != State.Play)
        {
            yield break;
        }
        _state = State.Score;
        _player1Logic.CanMove = false;
        _player2Logic.CanMove = false;
        UpdateScore(side == 1 ? 2 : 1);
        _servingPlayer = side == 1 ? 2 : 1;
        _AudioPlayer.PlayRefereeWhistle();
        yield return new WaitForSeconds(2);
        yield return SetupNewServe();
    }

    private void BallLogic_OutsideHit()
    {
        StartCoroutine(HandleSideHit(_servingPlayer));
    }

    private void UpdateScore(int scoringPlayer)
    {
        if (scoringPlayer == 1)
        {
            _player1Score += 1;
            _ScoreDisplay.SetScore1(_player1Score);
        }
        else if (scoringPlayer == 2)
        {
            _player2Score += 1;
            _ScoreDisplay.SetScore2(_player2Score);
        }
    }
}
