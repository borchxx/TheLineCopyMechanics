using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveSphere : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.1f;
    [SerializeField] private ScoreData _scoreData;
    [SerializeField] private TextMeshProUGUI _scoreTextField;
    [SerializeField] private LoadScene _sceneLoader;

    public static event GameOverEvent GameOver;
    public delegate void GameOverEvent();

    private bool _flagScore = true;
    private int _score = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rectangle")
        {
            GameOver();
            var anim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("gameOver", true);
            _flagScore = false;
            
            if (_scoreData.bestScore < _score)
            {
                _scoreData.bestScore = _score;
            }
            _scoreData.score = _score;
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        _sceneLoader.SceneLoader("GameOver");
    }

    void FixedUpdate()
    {
        if (_flagScore)
        {
            _score += 1;
            _scoreTextField.text = _score.ToString();
        } 
    }
}
