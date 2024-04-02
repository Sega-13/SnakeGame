using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] Button buttonStart;
    [SerializeField] Button buttonEnd;
    [SerializeField] Button buttonInstruction;
    [SerializeField] Button buttonBack;
    [SerializeField] Button buttonBackToMenu;
    [SerializeField] Button buttonOnePlayer;
    [SerializeField] Button buttonTwoPlayer;

    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject InstructionScreen;
    
    
    private void Awake()
    {
        buttonStart.onClick.AddListener(StartGame);
        buttonEnd.onClick.AddListener(QuitGame);
        buttonInstruction.onClick.AddListener(PlayInstruction);
        buttonBack.onClick.AddListener(GoToLobby);
        buttonBackToMenu.onClick.AddListener(BackToMenu);
        buttonOnePlayer.onClick.AddListener(OnePlayer);
        buttonTwoPlayer.onClick.AddListener(TwoPlayer);
    }
    public void StartGame()
    {
        StartScreen.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayInstruction()
    {
        InstructionScreen.SetActive(true);
    }
    public void GoToLobby()
    {
        InstructionScreen.SetActive(false);
    }
    public void BackToMenu()
    {
        StartScreen.SetActive(false);
    }
    public void OnePlayer()
    {
        SceneManager.LoadScene(1);
    }
    public void TwoPlayer()
    {
        SceneManager.LoadScene(2);
    }
}
