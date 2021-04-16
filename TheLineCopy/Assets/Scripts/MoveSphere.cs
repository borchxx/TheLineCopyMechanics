using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveSphere : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _moveSpeed = 0.1f;
    [SerializeField] private ScoreData _scoreData;
    [SerializeField] private TextMeshProUGUI _scoreTextField;
    [SerializeField] private LoadScene _sceneLoader;
    private bool _flagSwipe = false;
    private bool _flagScore = true;
    private int _score = 0;

    public void StartSwipe()
    {
        if (!_flagSwipe)
        {
            _flagSwipe = true;
        }
    }

    public void Swipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 0.01f, transform.position.y, transform.position.z);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rectangle")
        {
            _speed = 0;
            Renderer rend = collision.gameObject.GetComponent<Renderer>();
            rend.material.SetFloat("Alpha", 1);
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
        if (_flagSwipe && _flagScore)
        {
            Swipe();
        } 
        transform.position += transform.up * _speed * Time.deltaTime;
    }
}
