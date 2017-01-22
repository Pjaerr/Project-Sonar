using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //UI
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject instructionsUI;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private Text scoreText;

    //Game Manager Attributes and Objects
    public static GameManager instance;
    private int score;
    public GameObject Level;
    [SerializeField] private float levelMovementSpeed = 3;

    //Level Generation Stuff
    [SerializeField] private GameObject[] levelObjects; //Array of walls to be spawned.
    private int levelsPlaced = 0;
    private float lengthOfLevelObjects = 11.76f;
    [SerializeField] private Transform SpawnPoint;

    public void LevelGeneration() //Make initial start position be parameters that are passed. //Just uncomment pls.
    {
        if (levelsPlaced == levelObjects.Length)
        {
            levelsPlaced = 0;
        }
        
        Instantiate(levelObjects[levelsPlaced], levelObjects[levelsPlaced].GetComponent<Transform>().position = SpawnPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)), Level.GetComponent<Transform>());

        levelsPlaced++;

    }

    void Awake()
    {
        Singleton();
    }
    void Update()
    {
        if (scoreText != null)
        {
            Score();
        }
        
        MoveLevel();
    }

    void Singleton()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
   
    void MoveLevel()
    {
        if (Level != null)
        {
            Level.GetComponent<Rigidbody2D>().velocity = new Vector2(-levelMovementSpeed, 0);
        }
    }

    //UI Functions
    public void PlayGame(bool playGame)
    {
        if (playGame)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Application.Quit();
        }
    }
    public void MenuControl(string menuName)
    {
        if (menuName == "Instructions")
        {
            mainMenuUI.SetActive(false);
            instructionsUI.SetActive(true);
        }
        else if (menuName == "Mainmenu")
        {
            instructionsUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
    }
    void Score()
    {
        score = (int)Time.timeSinceLevelLoad;
        scoreText.text = score.ToString();
    }
    public void UIControl()
    {
        deathUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
