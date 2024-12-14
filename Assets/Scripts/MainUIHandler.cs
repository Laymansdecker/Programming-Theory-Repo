using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public GameObject gameOverText;         //a variable to hold the game over text
    public GameObject playAgainButton;      //a variable to hold the play again button
    public GameObject mainMenuButton;       //a variable to hold the main menu button

    public Timer timer;                     //allowing the reference of the Timer script

    private void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>(); //sets the Timer script to the timer game object
    }

    void Update()   // Update is called once per frame
    {
        if (DataManager.Instance.gameOver == true)      //if the game has ended
        {
            GameOverUI();                               //show the end game ui
        }
    }

    private void GameOverUI()   //controls the ui for the end game
    {
        gameOverText.SetActive(true);                   //reveals the game over text
        playAgainButton.SetActive(true);                //reveals the play again button
        mainMenuButton.SetActive(true);                 //reveals the main menu button
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);                      //loads the main menu
    }

    public void PlayAgain()
    {
        DataManager.Instance.gameOver = false;           //turn off the game over
        timer.elapsedTime = 0f;                          //reset the timer to 0
        gameOverText.SetActive(false);                   //reveals the game over text
        playAgainButton.SetActive(false);                //reveals the play again button
        mainMenuButton.SetActive(false);                 //reveals the main menu button
    }


}
