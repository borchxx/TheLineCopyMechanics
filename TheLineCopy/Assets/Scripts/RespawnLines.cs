using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLines : MonoBehaviour
{
    public static event GenerateLine GenerateLines;
    public delegate void GenerateLine();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rectangle" || collision.gameObject.tag == "EmptyRectangle")
        {
            Destroy(collision.gameObject);
            GenerateLines();
        }
    }
}
