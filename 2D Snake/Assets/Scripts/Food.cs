using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]private Snake snake;
    private int score = 0;
    [SerializeField]private TextMeshProUGUI scoreText;

   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Snake>() != null)
        {
            score++;
            scoreText.text = score.ToString();
            ChangePosition();
            snake.Grow();
        }
    }
    
    void ChangePosition()
    {
        this.transform.position = new Vector2(Random.Range(snake.Left.transform.position.x,snake.Right.transform.position.x),
            Random.Range(snake.Top.transform.position.y,snake.Bottom.transform.position.y));
    }
}
