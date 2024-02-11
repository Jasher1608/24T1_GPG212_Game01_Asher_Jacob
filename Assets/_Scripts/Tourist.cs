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
    public new string name { get; private set; }
    public int weight { get; private set; }
    public string dateOfBirth { get; private set; }
    public char sex { get; private set; }
    public string expiryDate { get; private set; }
    public Sprite face { get; private set; }
    public int faceIndex { get; private set; }

    public bool isPassportCorrect; // Can be set from Passport script

    [SerializeField] private GameObject AlcardianPassport;
    [SerializeField] private GameObject BrothnianPassport;
    [SerializeField] private GameObject CrazniriPassport;
    [SerializeField] private GameObject DilcinianPassport;

    private void Start()
    {
        lists = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TouristListHolder>();
        sr = GetComponent<SpriteRenderer>();

        InitializeTourist();
        GeneratePassport();
    }

    private void InitializeTourist()
    {
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
            faceIndex = Random.Range(0, lists.maleFaces.Count);
            face = lists.maleFaces[faceIndex];
        }
        else
        {
            Random.Range(0, lists.femaleFaces.Count);
            face = lists.femaleFaces[faceIndex];
        }
        sr.sprite = face;

        // Passport
        isPassportCorrect = (Random.Range(0, 2) == 1);
    }

    private void GeneratePassport()
    {
        if (isPassportCorrect)
        {
            switch (nationality)
            {
                case Nationality.Alcardian:
                    Instantiate(AlcardianPassport);
                    break;
                case Nationality.Brothnian:
                    Instantiate(BrothnianPassport);
                    break;
                case Nationality.Crazniri:
                    Instantiate(CrazniriPassport);
                    break;
                case Nationality.Dilcinian:
                    Instantiate(DilcinianPassport);
                    break;
            }
        }
        else
        {
            int randomPassport = Random.Range(1, 5);

            switch (randomPassport)
            {
                case 1:
                    Instantiate(AlcardianPassport);
                    break;
                case 2:
                    Instantiate(BrothnianPassport);
                    break;
                case 3:
                    Instantiate(CrazniriPassport);
                    break;
                case 4:
                    Instantiate(DilcinianPassport);
                    break;
            }
        }
    }
}

public enum Nationality
{
    Alcardian,
    Brothnian,
    Crazniri,
    Dilcinian
}
