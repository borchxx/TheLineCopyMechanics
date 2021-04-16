using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private ScoreData _scoreData;
    void Start()
    {
        _bestScore.text = _scoreData.bestScore.ToString();
        _score.text = _scoreData.score.ToString();
    }
}
