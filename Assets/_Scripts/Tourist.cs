using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tourist : MonoBehaviour
{
    public Nationality nationality { get; private set; }
    public int age { get; private set; }
    public int height { get; private set; }
    public int weight { get; private set; }
    public string expiryDate { get; private set; }
    
    // Constructor
    public Tourist()
    {
        nationality = (Nationality)Random.Range(0, 4);
        age = (int)Random.Range(18, 80);
        height = Random.Range(150, 200);
        weight = Random.Range(50, 200);

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}

public enum Nationality
{
    Alcardian,
    Brothnian,
    Crazniri,
    Dilcinian
}
