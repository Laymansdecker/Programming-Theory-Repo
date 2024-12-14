using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public PlayerController playerController;
    private float spawnPosY = 0.5f;
    private float startDelay = 0f;
    private float spawnInterval = 2f;

    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();   //finds the player controller and sets it to playerController
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);    //runs the SpawnRandomAnimal method at the start delay and then again at every SpawnInterval time
    }

    private void Update()
    {
        if (DataManager.Instance.gameOver == true)
        {
            CancelInvoke("SpawnRandomAnimal");
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);    //chooses a random number between 0 and the size of the array of GameObjects
        Vector3 SpawnPos = new Vector3(Random.Range(-playerController.MovementLimit, playerController.MovementLimit), spawnPosY, playerController.MovementLimit);    //set the spawn point for the instantiated object
        Instantiate(animalPrefabs[animalIndex], SpawnPos, animalPrefabs[animalIndex].transform.rotation);   //spawns an object at the SpawnPos location with its own rotation
    }
}
