 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerName;   //variable for controlling the text input
    public string highScoreText;        //text that displays the high score of the game
    public GameObject enterNameAlert;   //text that alerts the player to insert a name before beginning the game
    private int characterLimit = 8;     //number of characters allowed for the player's name

    
    public void StartGame() //to start a new game
    {
        if (string.IsNullOrWhiteSpace(playerName.text) != true)         //checks if the player has confirmed a name and not left it blank
        {
            enterNameAlert.SetActive(false);                            //turn off the insert name text
            DataManager.Instance.activePlayerName = playerName.text;    //sets the player's name as the placeholder in DataManager
            SceneManager.LoadScene(1);                                  //SceneManager is the class that handles everything related to loading and unloading scenes
                                                                        //Scene number can be found in File/Build settings
        }
        else                                                            //if it is blank
        {
            enterNameAlert.SetActive(true);                             //make the insert name text appear
        }
    }

    public void GameOver()  //when the player hits an enemy
    {
        DataManager.Instance.SaveGame();    //save the game
    }

    public void ExitGame()  //to close the game      
    {
#if UNITY_EDITOR                            //if running in the game editor
        EditorApplication.ExitPlaymode();   //close the game
#else                                       //else if running as a build
        Application.Quit();                 //close the game
#endif                                      
    }

    public void CharacterLimit()    //creates a character limit for the input player name input field
    {
        playerName.characterLimit = characterLimit; //applied to the On Value Changed section to update the input name length to the characterLimit
    }



}
