using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tourist : MonoBehaviour
{
    [SerializeField] private FacesHolder facesHolder;

    public Nationality nationality { get; private set; }
    public int height { get; private set; }
    public int weight { get; private set; }
    public string dateOfBirth { get; private set; }
    public char sex { get; private set; }
    public string expiryDate { get; private set; }
    public Sprite face { get; private set; }

    private void Start()
    {
        nationality = (Nationality)Random.Range(0, 4);
        height = Random.Range(150, 200);
        weight = Random.Range(50, 200);

        // Sex
        int sexNumber = Random.Range(0, 2);
        sex = sexNumber == 0 ? 'M' : 'F';

        // DOB
        int day = Random.Range(1, 29);
        int month = Random.Range(1, 13);
        int year = Random.Range(1969, 2005);
        dateOfBirth = string.Format("{0:D2}/{1:D2}/{2:D4}", day, month, year);

        // Expiry date
        day = Random.Range(1, 29);
        month = Random.Range(1, 13);
        year = Random.Range(2017, 2034);
        expiryDate = string.Format("{0:D2}/{1:D2}/{2:D4}", day, month, year);

        // Sprite
        if (sex == 'M')
        {
            face = facesHolder.maleFaces[Random.Range(0, facesHolder.maleFaces.Count)];
        }
        else
        {
            face = facesHolder.femaleFaces[Random.Range(0, facesHolder.femaleFaces.Count)];
        }
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
