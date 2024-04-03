using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Snake : MonoBehaviour
{
    
    enum powerup
    {
        Shield,
        ScoreBoost,
        SpeedUp

    }
    
    public Vector3 direction = Vector3.right;
    List<Transform> segment = new List<Transform>();
    [SerializeField]private GameObject snakeBodyPrefab;
    [SerializeField] private  Walls  walls;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private MassGainer massGainer;
    [SerializeField] private MassBuner burner;
    [SerializeField] private Snake snake;
    [SerializeField] private Food food;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI winnerName;
    public GameObject shield;
    private Boolean isShieldActive;
    public Boolean isGainerActivated;
    public Boolean isBurnerActivated;
    float shieldCurrentTime, shieldMaxTime;
    float speedUpCurrentTimer, speedUpMaxTimer;
    private float speed;
    private Boolean isSpeedUp;
    public Boolean isGameOver;
    private static int blueSegment, greenSegment;
    private Transform SegmentVal;

   
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            UpdateHighScoreText();
        }
       
        speed = 0.7f;
        segment.Add(this.transform);
        shieldMaxTime = 10;
        speedUpMaxTimer = 5;
        shieldCurrentTime = shieldMaxTime;
        speedUpCurrentTimer = speedUpMaxTimer;
        StartCoroutine(ActivatePowerUp());
       
    }
  
    
    
    void Update()
    {
        if(!isGameOver)
        {
            if(snake.gameObject.name == "Snake")
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector3.down)
                {
                    direction = Vector3.up;

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector3.left)
                {
                    direction = Vector3.right;
                }
                if ((direction == Vector3.up || direction == Vector3.down) && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    direction = Vector3.left;
                }

                if ((direction == Vector3.right || direction == Vector3.left) && Input.GetKeyDown(KeyCode.DownArrow))
                {
                    direction = Vector3.down;
                }
            }
            if(snake.gameObject.name == "SnakeBlue")
            {
                if (Input.GetKeyDown(KeyCode.W) && direction != Vector3.down)
                {
                    direction = Vector3.up;

                }
                else if (Input.GetKeyDown(KeyCode.D) && direction != Vector3.left)
                {
                    direction = Vector3.right;
                }
                if ((direction == Vector3.up || direction == Vector3.down) && Input.GetKeyDown(KeyCode.A))
                {
                    direction = Vector3.left;
                }

                if ((direction == Vector3.right || direction == Vector3.left) && Input.GetKeyDown(KeyCode.S))
                {
                    direction = Vector3.down;
                }
            }

            if (isShieldActive)
            {
                shieldCurrentTime -= Time.deltaTime;
                if (shieldCurrentTime <= 0)
                {
                    isShieldActive = false;
                    shield.gameObject.SetActive(false);
                    shieldCurrentTime = shieldMaxTime;
                }
            }
            if (isSpeedUp)
            {
                speedUpCurrentTimer -= Time.deltaTime;
                if (speedUpCurrentTimer <= 0)
                {
                    SetSpeed(0.7f);
                    speedUpCurrentTimer = speedUpMaxTimer;
                    isSpeedUp = false;
                }

            }
           
        }




    }
    public static readonly System.Random randomGen = new System.Random();
    public static T GetRandomEnumValue<T>(T[] enumValues) where T : Enum
    {
        int randomIndex = randomGen.Next(0, enumValues.Length);
        return enumValues[randomIndex];
    }
    IEnumerator ActivatePowerUp()
    {
        while(!isGameOver)
        {
            int random = (int)GetRandomEnumValue(new powerup[] { powerup.Shield, powerup.ScoreBoost, powerup.SpeedUp });
            //  Debug.Log("Random " + random);
            switch (random)
            {
                case 0:
                    MakeShieldActive();
                    break;
                case 1:
                    massGainer.InstanciateMassGainer();
                    break;
                case 2:
                    isSpeedUp = true;
                    float speedVal = 2 * speed;
                    SetSpeed(speedVal);
                    break;
            }
            yield return new WaitForSeconds(15);
        }
       
        
    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            for (int i = segment.Count - 1; i > 0; i--)
            {
                if (segment[i] != null)
                {
                    segment[i].position = segment[i - 1].position;
                }
            }
            //Snake movement

            Vector3 snakePosition = new Vector3(this.transform.position.x, this.transform.position.y, 0) + direction * speed;
            if (snakePosition.x > walls.GetBounds().max.x)
            {
                snakePosition.x = walls.GetBounds().min.x;
            }
            else if (snakePosition.x < walls.GetBounds().min.x)
            {
                snakePosition.x = walls.GetBounds().max.x;
            }
            if (snakePosition.y > walls.GetBounds().max.y)
            {
                snakePosition.y = walls.GetBounds().min.y;
            }
            else if (snakePosition.y < walls.GetBounds().min.y)
            {
                snakePosition.y = walls.GetBounds().max.y;
            }
            this.transform.position = snakePosition;

        }
        
    }
    public void Grow()
    {
        Transform segmentPart = Instantiate(this.snakeBodyPrefab, segment[segment.Count - 1].position,Quaternion.identity).transform;
        segment.Add(segmentPart);
        
      
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (segment.Count > 2)
            {
                burner.massBurnerActivated = true;
            }
        }
        if (greenSegment > 2 && blueSegment > 2)
        {
            burner.massBurnerActivated = true;
        }
        if (snake.gameObject.name == "Snake")
        {
            greenSegment++;
        }
        if (snake.gameObject.name == "SnakeBlue")
        {
            blueSegment++;
        }



    }
    public int  GetSegmentCount()
    {
        return segment.Count;
    }
    public void CheckHighScore()
    {
        if(food.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore",food.score);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isShieldActive)
        {
            if (collision.gameObject.tag == "obs")
            {
                isGameOver = true;
                if (snake.gameObject.name == "Snake")
                {
                    CheckHighScore();
                }
                if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    if(food.score > food.GetBlueScore())
                    {
                        winnerName.text = "GreenSnake";
                    }
                    else if(food.score < food.GetBlueScore())
                    {
                        winnerName.text = "BlueSnake";
                    }
                    else
                    {
                        winnerName.text = "None";
                    }
                }
               

                

                if (snake.gameObject.name == "SnakeBlue" || snake.gameObject.name == "Snake")
                {
                    snake.gameObject.SetActive(false);
                   
                }
                if(collision.gameObject.name == "Snake" || collision.gameObject.name == "SnakeBlue")
                {
                    collision.gameObject.SetActive(false);
                    
                   
                }
                for (int i = 0; i < segment.Count; i++)
                {
                    Destroy(this.segment[i].gameObject);
                }
                segment.Clear();
                
                
                StopCoroutine(ActivatePowerUp());
                food.gameObject.SetActive(false);
               // collision.gameObject.SetActive(false);
                GameOverScreen.SetActive(true);
                
            }
            
        }
        
        if (collision.GetComponentInParent<Walls>() != null)
        {
            ChangeDirection();
        }
        if(collision.GetComponentInParent<MassGainer>() != null)
        {
            isGainerActivated = true;
            massGainer.GetMassGainerVal().gameObject.SetActive(false);
            if(snake.gameObject.name == "Snake")
            {
                food.SnakeScoreBooster();
            }else if(snake.gameObject.name == "SnakeBlue")
            {
                food.SnakeBlueScoreBooster();
            }
        }
        if (collision.GetComponentInParent<MassBuner>() != null)
        {
            isBurnerActivated = true;
            burner.GetMassBurnerVal().gameObject.SetActive(false);
            Destroy(segment[segment.Count - 1].gameObject);
            segment.RemoveAt(segment.Count - 1);
            
        }
     
        
        
        
    }
    public void Restart()
    {
        GameOverScreen.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex == 1) {
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(2);
        }


    }
    void ChangeDirection()
    {
        if (direction == Vector3.left)
        {
            this.transform.position = new Vector3(walls.GetRight().transform.position.x ,
      this.transform.position.y,0)+direction*speed;
        }
        if (direction == Vector3.right)
        {
            this.transform.position = new Vector3(walls.GetLeft().transform.position.x ,
      this.transform.position.y,0)+direction*speed;
        }
        if (direction == Vector3.up)
        {
            this.transform.position = new Vector3(this.transform.position.x,
      walls.GetBottom().transform.position.y,0)+direction*speed;
        }
        if (direction == Vector3.down)
        {
            this.transform.position = new Vector3(this.transform.position.x,
      walls.GetTop().transform.position.y,0)+direction*speed;
        }
    }


    private void MakeShieldActive()
    {
        isShieldActive = true;
        shield.gameObject.SetActive(true);

    }
    void UpdateHighScoreText()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

}
