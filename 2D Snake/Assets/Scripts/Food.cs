using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Walls walls;
    [SerializeField] private Snake snake;
    public int score = 0;
   
    [SerializeField] public TextMeshProUGUI scoreText;
    
    [SerializeField] private GameObject massGainer;
   
   
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
    private void Update()
    {
        if(snake.isGainerActivated)
        {
            score = 2 * score;
            scoreText.text = score.ToString();
            snake.isGainerActivated = false;
        }
       
     
    }
    public void ChangePosition()
    {
        this.transform.position = new Vector3(Random.Range(walls.GetLeft().transform.position.x+3,walls.GetRight().transform.position.x - 3),
            Random.Range(walls.GetTop().transform.position.y-3,walls.GetBottom().transform.position.y + 3),0);
    }

    
}
