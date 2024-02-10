using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tourist : MonoBehaviour
{
    [SerializeField] private TouristListHolder lists;

    [SerializeField] private SpriteRenderer sr;

    public Nationality nationality { get; private set; }
    public string name { get; private set; }
    public int weight { get; private set; }
    public string dateOfBirth { get; private set; }
    public char sex { get; private set; }
    public string expiryDate { get; private set; }
    public Sprite face { get; private set; }

    private void Start()
    {
        lists = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TouristListHolder>();
        sr = GetComponent<SpriteRenderer>();

        nationality = (Nationality)Random.Range(0, 4);
        weight = Random.Range(50, 200);

        // Sex
        int sexNumber = Random.Range(0, 2);
        sex = sexNumber == 0 ? 'M' : 'F';

        // Name
        if (sex == 'M')
        {
            string firstName = lists.maleFirstNames[Random.Range(0, lists.maleFirstNames.Count)];
            string lastName = lists.lastNames[Random.Range(0, lists.lastNames.Count)];
            name = string.Format("{0}, {1}", lastName, firstName);
        }
        else
        {
            string firstName = lists.femaleFirstNames[Random.Range(0, lists.femaleFirstNames.Count)];
            string lastName = lists.lastNames[Random.Range(0, lists.lastNames.Count)];
            name = string.Format("{0}, {1}", lastName, firstName);
        }

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
            face = lists.maleFaces[Random.Range(0, lists.maleFaces.Count)];
        }
        else
        {
            face = lists.femaleFaces[Random.Range(0, lists.femaleFaces.Count)];
        }
        sr.sprite = face;
    }
}

public enum Nationality
{
    Alcardian,
    Brothnian,
    Crazniri,
    Dilcinian
}
