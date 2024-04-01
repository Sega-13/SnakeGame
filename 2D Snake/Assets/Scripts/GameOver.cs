using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button buttonRestart;
    [SerializeField] Button buttonMenu;
    [SerializeField]Snake snake;
    private void Awake()
    {
        

    }
  
    void Start()
    {
       
        buttonMenu.onClick.AddListener(GoToMenu);
        buttonRestart.onClick.AddListener(RestartGame);

    }
    void RestartGame()
    {
        snake.Restart();
    }
    void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        
    }
}
