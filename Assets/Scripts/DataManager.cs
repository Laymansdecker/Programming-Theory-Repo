using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;                        //created to allow the use of TextMeshPro objects
using System.IO;                    //used to save/load games and write JSON files

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;         //a static value to store the save game. the value saved in this class will be shared by all instances of this class. 
    public GameObject GameOverText;
    public TextMeshProUGUI HighScoreTime;
    public TextMeshProUGUI HighScoreName;

    public string activePlayerName;             //variable to hold an active player's name
    public float activePlayerTime;              //variable to hold active player's time
    public string highScorePlayerName;          //variable to hold the high score name
    public float highScoreElapsedTime;         //variable to hold the high score time

    public bool gameOver = false;               //controller to turn things of and on when game over occurs

    private void Awake()
    {
        if (Instance != null)           //checks to see if there is an instance already present. If there is one already present,
        {
            Destroy(gameObject);        //destroy it when a new one is created
            return;
        }

        Instance = this;                //'this' represents the current instance of MainManager. it stores it in Instance.
        DontDestroyOnLoad(gameObject);  //does not destroy when the scene changes

        LoadGame();
    }

    [System.Serializable]   //for a variable to be saveable, it must be writeable in a system.serializable section
    class SaveData          //defines the savable data for the JSON file
    {
        public string highScorePlayerName;          //variable to hold the high score name
        public float highScoreElapsedTime;         //variable to hold the high score time
    }
    
    public void SaveGame()  //saves the player name and the high score
    {
        SaveData data = new SaveData();                                                 //creates a new instance of savedata
        data.highScorePlayerName = highScorePlayerName;                                 //files in the player name and timer with the variables saved in MainManager
        data.highScoreElapsedTime = highScoreElapsedTime;

        string json = JsonUtility.ToJson(data);                                         //transforms the instance to JSON with JsonUtility.ToJson

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);     //writes a sring to a file
    }

    public void LoadGame()  //loads the player name and the high score
    {
        string path = Application.persistentDataPath + "/savefile.json";                //looks for a save file in this location
        if (File.Exists(path))                                                          //if a file exists,
        {
            string json = File.ReadAllText(path);                                       //read all the content contained
            SaveData data = JsonUtility.FromJson<SaveData>(json);                       //and transform it back from a JSON to a SaveData Instance

            highScorePlayerName = data.highScorePlayerName;                             //sets the high score name to whatever was saved in the SaveData file
            highScoreElapsedTime = data.highScoreElapsedTime;                           //sets the high score time to whatever was saved in the SaveData file

            HighScoreName.text = highScorePlayerName;                                   //updates high score name
            int minutes = Mathf.FloorToInt(highScoreElapsedTime / 60);                                               //calculates the minutes elapsed by dividing by 60
            int seconds = Mathf.FloorToInt(highScoreElapsedTime % 60);                                               //calculates seconds by producing the remainder of the minutes calculation
            float miliseconds = Mathf.FloorToInt((highScoreElapsedTime - seconds) * 100);                            //calculates the miliseconds
            HighScoreTime.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);               //updates high score text
        }
    }

    public void GameOver()  //conditions when the player loses the game
    {
        gameOver = true;                                                                //sets the game over bool to true
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");              //function to destroy all present enemies in the game. Finds all enemies in the scene with the "Enemy" tag
        foreach(GameObject enemy in enemies)                                            //for every enemy found
        {
            Destroy(enemy);                                                             //destroy it
        }

        if (activePlayerTime > highScoreElapsedTime)                                    //if a player has beat the previous high score
        {
            highScorePlayerName = activePlayerName;                                     //set the active player name to the highscore player name
            highScoreElapsedTime = activePlayerTime;                                    //set the active player time to the highscore player time
            SaveGame();                                                                 //save these scores to the json file
        }
    }





}
