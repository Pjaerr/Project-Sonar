using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    //General Level Stuff
    public GameObject Level; //The GameObject holding all level elements as children.
    [SerializeField] private float levelMovementSpeed = 3; 

    //Level Generation Stuff
    [SerializeField] private GameObject[] levelObjects; //Array of walls to be spawned.
    private int levelsPlaced = 0; //Amount of levels currently in scene.
    [SerializeField] private Transform SpawnPoint; //The place (at the edge of the camera) where newer levels are to be spawned. 

    void Start()
    {
        LevelMovement();
    }

    /*Places level objects from the levelObjects[] array at the set SpawnPoint position*/
    public void LevelPlacement()
    {
        //This function is called every time a levelObject's spawnTrigger hits the world space spawnTrigger
        /*if (levelsPlaced == levelObjects.Length)
        {
            levelsPlaced = 0;
        }*/

        int rand = Random.Range(0, levelObjects.Length);
        Debug.Log("Random Number = " + rand);

        Instantiate(levelObjects[rand], levelObjects[rand].GetComponent<Transform>().position = SpawnPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)), Level.GetComponent<Transform>());

        levelsPlaced++;

    }

    /*Used to move the level at a rate of levelMovementSpeed to the left of the screen.*/
    void LevelMovement()
    {
        if (Level != null)
        {
            Level.GetComponent<Rigidbody2D>().velocity = new Vector2(-levelMovementSpeed, 0);
        }
    }

}
