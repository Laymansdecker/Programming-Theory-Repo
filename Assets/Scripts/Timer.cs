using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; //an array to hold the high scores
    public float elapsedTime;                   //variable to hold the time elapsed during a round
    private void Update()
    {
        if (DataManager.Instance.gameOver != true)      //if the game hasn't ended
        {   
            TimerCount();                               //calls the timer method
        }
        
    }

    private void TimerCount()    //calculates time elapsed in the game
    {
        elapsedTime += Time.deltaTime;                                                                  //adds the change in time to the timer variable
        int minutes = Mathf.FloorToInt(elapsedTime / 60);                                               //calculates the minutes elapsed by dividing by 60
        int seconds = Mathf.FloorToInt(elapsedTime % 60);                                               //calculates seconds by producing the remainder of the minutes calculation
        float miliseconds = Mathf.FloorToInt((elapsedTime - seconds) * 100);                            //calculates the miliseconds
        DataManager.Instance.activePlayerTime = elapsedTime;                                            //sets the activeplayertime in datamanager
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);          //updates timeText to display the time in the set format
    }
}