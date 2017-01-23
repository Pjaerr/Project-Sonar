using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Attributes and Objects
    private Rigidbody2D rb;
    private Transform trans;
    [SerializeField]
    private float movementSpeed = 4;
    private AudioSource sonarSound;

    //Sonar Attributes and Objects
    public GameObject Sonar; //Reveals the level objects.

    //Level Attributes and Objects
    [SerializeField]
    private GameObject Level;
    [SerializeField]
    private GameObject Bugs;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        sonarSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        MovementAndControls();
    }

    void FireSonar()
    {
        //Add checks here for cooldowns.
        if (!IsSonar())
        {
            Instantiate(Sonar, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))); //Spawns a sonar object at the position of the player with default rotation.
            sonarSound.Play();
        }
    }

    bool IsSonar()
    {
        if (GameObject.FindGameObjectWithTag("Sonar"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void MovementAndControls()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0, movementSpeed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0, -movementSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero; //If no key is being pressed, make player velocity 0.
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireSonar();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.Pause(true);
        }
    }

    void ResetGame()
    {
        if (!IsSonar())
        {
            FireSonar();
        }

        GameManager.instance.OnDeathControl("OpenDeathUI");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            ResetGame();
        }
    }
}
