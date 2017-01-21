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

    public GameObject firstWall;
    public GameObject firstWallEndPoint;
    public GameObject secondWall;
    public GameObject secondWallStartPoint;
    

    void Awake()
    {
        Singleton();
    }
    void Update()
    {
        Score();
        //MoveLevel();
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
            float var2 = levelMovementSpeed + (Time.time * 0.01f);
            Level.GetComponent<Rigidbody2D>().velocity = new Vector2(-var2, 0);
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
        score = (int)Time.time;
        scoreText.text = score.ToString();
    }
    public void UIControl()
    {
        deathUI.SetActive(true);
    }

    //Level Generation

    public void LevelGen()
    {
        //Vector2 endPointWorld = new Vector2(0, firstWall.GetComponent<Transform>().position.y - firstWallEndPoint.GetComponent<Transform>().position.y);

        secondWall.GetComponent<Transform>().position = firstWallEndPoint.GetComponent<Transform>().position;

        secondWall.GetComponent<Transform>().position = new Vector2(secondWall.GetComponent<Transform>().position.x, secondWall.GetComponent<Transform>().position.y - secondWallStartPoint.GetComponent<Transform>().localPosition.y);
        
        
        
        //Vector2 var = new Vector2(0, secondWallStartPoint.GetComponent<Transform>().localPosition.y + secondWall.GetComponent<Transform>().position.y);


        //secondWall.GetComponent<Transform>().position = new Vector2(14.8f, secondWall.GetComponent<Transform>().position.y + var.y);

        Debug.Log("LevelGen() called!");
    }




}
