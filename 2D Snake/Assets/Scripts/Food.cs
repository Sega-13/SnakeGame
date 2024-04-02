using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Walls walls;
    public int score = 0;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI blueScoreText;
    [SerializeField] private GameObject massGainer;
    private Snake snake;
    private int blueScore;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        snake = collision.gameObject.GetComponent<Snake>();
        if (collision.gameObject.GetComponent<Snake>() != null)
        {
            
           
            
            if (snake.gameObject.name == "Snake")
            {
                score++;
                scoreText.text = score.ToString();
                ChangePosition();
                snake.Grow();
            }
            else if (snake.gameObject.name == "SnakeBlue")
            {
                blueScore++;
                blueScoreText.text = blueScore.ToString();
                ChangePosition();
                snake.Grow();
            }


        }
        
    }
    private void Update()
    {
      

    }
    public void SnakeScoreBooster()
    {
        score = 2 * score;
        scoreText.text = score.ToString();
    } 
    public void SnakeBlueScoreBooster()
    {
        blueScore = 2 * blueScore;
        blueScoreText.text = blueScore.ToString();
    }
    public void ChangePosition()
    {
        this.transform.position = new Vector3(Random.Range(walls.GetLeft().transform.position.x+3,walls.GetRight().transform.position.x - 3),
            Random.Range(walls.GetTop().transform.position.y-3,walls.GetBottom().transform.position.y + 3),0);
    }

    
}
