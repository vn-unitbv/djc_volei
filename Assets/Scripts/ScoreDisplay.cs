using TMPro;
using UnityEngine;

class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _Score1;
    [SerializeField]
    private TMP_Text _Score2;
    [SerializeField]
    private TMP_Text _Name1;
    [SerializeField]
    private TMP_Text _Name2;
    [SerializeField]
    private TMP_Text _Set;

    public void SetScore1(int score)
    {
        _Score1.text = score.ToString();
    }

    public void SetScore2(int score)
    {
        _Score2.text = score.ToString();
    }

    public void SetPlayerName1(string playerName)
    {
        _Name1.text = playerName;
    }

    public void SetPlayerName2(string playerName)
    {
        _Name2.text = playerName;
    }

    public void SetSetNumber(int n)
    {
        _Set.text = $"Set {n}";
    }
}