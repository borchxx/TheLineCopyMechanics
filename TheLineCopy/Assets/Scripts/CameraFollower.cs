using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    //[SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private void Start()
    {
        MoveSphere.GameOver += GameOver;
    }

    private void GameOver()
    {
        _speed = 0;
    }

    void FixedUpdate()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
       // transform.position = new Vector3(0, _player.position.y  + 2, -10);
    }
}
