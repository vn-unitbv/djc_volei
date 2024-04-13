using System.Collections;
using System.Collections.Generic;
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

    private BallScript _ballLogic;

    private int _player1Score = 0;
    private int _player2Score = 0;

    private void Awake()
    {
        _ballLogic = _Ball.GetComponent<BallScript>();
        _ballLogic.SideHit += BallLogic_SideHit;
    }

    void Start()
    {
        SetupNewServe();
    }

    void Update()
    {

    }

    private void SetupNewServe()
    {
        _Player1.transform.position = new Vector3(0.0f, 2.73f, 8.67f);
        _Player2.transform.position = new Vector3(0.0f, 2.73f, -8.67f);
        _ballLogic.TempInitialLaunch();
    }

    private void BallLogic_SideHit(int side)
    {
        UpdateScore(side == 1 ? 2 : 1);
        SetupNewServe();
    }


    [SerializeField]
    private TMP_Text _Score1;
    [SerializeField]
    private TMP_Text _Score2;

    private void UpdateScore(int scoringPlayer)
    {
        if (scoringPlayer == 1)
        {
            _player1Score += 1;
            _Score1.text = _player1Score.ToString();
        }
        else if (scoringPlayer == 2)
        {
            _player2Score += 1;
            _Score2.text = _player2Score.ToString();
        }
    }
}
