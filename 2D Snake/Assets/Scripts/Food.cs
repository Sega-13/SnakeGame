using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Snake>() != null)
        {
            Snake snake = collision.gameObject.GetComponent<Snake>();
            snake.Grow();
        }
    }
}
