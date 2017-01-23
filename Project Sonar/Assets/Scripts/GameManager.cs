using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //UI
    [SerializeField] private GameObject mainMenuUI; //UI containing main menu elements. Scene: MainMenu.
    [SerializeField] private GameObject instructionsUI; //UI containing instruction elements. Scene: MainMenu.
    [SerializeField] private GameObject deathUI; //UI containing death screen elements. Scene: main.
    [SerializeField] private GameObject pauseUI; //UI containing pause menu elements. Scene: main.
    [SerializeField] private Text scoreText; //UI containing score. Scene: main.

    //Game Manager Attributes and Objects
    public static GameManager instance; //The singleton instance of GameManager. No other instance shall exist as per the Singleton() method.
    private int score;
    
    //Unity Functions
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
    }

    //System Functions
    void Singleton() //Makes this script the only instance of this script, allows accessing public methods and variables without spreading out references.
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

    /*The opening and closing of UI menus in the MainMenu scene*/
    public void MainMenuControl(string menuName)
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

    /*Stores the time passed since the scene was loaded and prints it to the screen.*/
    void Score()
    {
        score = (int)Time.timeSinceLevelLoad;
        scoreText.text = "Score: " + score.ToString();
    }

    /*Control of objects and UI on death*/
    public void OnDeathControl(string whatToDo)
    {
        if (whatToDo == "OpenDeathUI")
        {
            Time.timeScale = 0;
            deathUI.SetActive(true);
        }
        else if (whatToDo == "RestartGame")
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
        else if (whatToDo == "OpenMainMenu")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

    /*Pausing and unpausing game*/
    public void Pause(bool pause)
    {
        if (deathUI.activeSelf == false)
        {
            if (pause)
            {
                Time.timeScale = 0;
                pauseUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseUI.SetActive(false);
            }
        }
        
    }
}
