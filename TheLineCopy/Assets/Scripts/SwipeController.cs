using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private bool _swipeFlag = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (_swipeFlag)
        {
            Swipe();
        }
    }

    public void StartSwipe()
    {
        if (!_swipeFlag)
        {
            _swipeFlag = true;
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
}
