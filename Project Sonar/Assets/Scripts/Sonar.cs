using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    //Default sonar scale is 0.08f
    public GameObject levelSonar; //Reveals the level objects.
    [SerializeField] private float sonarLifespan = 3f;
    [SerializeField] private float scalingIncrement = 0.01f;

    void Start()
    {
        ScaleSonar();
    }

    void ScaleSonar()
    {
        //Increase sonar size by scalingIncrement until sonarLifespan has passed. Maybe need to use IEnumerator.
    }
}
