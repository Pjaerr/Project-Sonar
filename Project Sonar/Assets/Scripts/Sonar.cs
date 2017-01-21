using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    //Default sonar scale is 0.08f

    //Sonar Attributes and Objects
    private Transform trans;
    [SerializeField] private float sonarLifespan = 3f;
    [SerializeField] private float scalingIncrement = 0.001f;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        StartCoroutine(ScaleSonar());
    }

    IEnumerator ScaleSonar()
    {
        float timePassed = 0;
        do
        {
            trans.localScale = new Vector2(trans.localScale.x + scalingIncrement, trans.localScale.y + scalingIncrement);
            yield return new WaitForSeconds(0.1f);

            timePassed += 0.1f;

        } while (timePassed <= sonarLifespan);

        Destroy(this.gameObject);
     }
  }
