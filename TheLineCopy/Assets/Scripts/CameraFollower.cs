using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;
    

    void FixedUpdate()
    {
        transform.position = new Vector3(0, _player.position.y  + 2, -10);
    }
}
