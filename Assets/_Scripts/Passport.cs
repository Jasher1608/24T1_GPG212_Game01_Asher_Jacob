using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Random = UnityEngine.Random;

public class Passport : MonoBehaviour
{
    private Tourist tourist;
    private TouristListHolder lists;

    private Nationality nationality;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image photo;
    [SerializeField] private int passportFaceIndex;
    [SerializeField] private string serialNumber;
    [SerializeField] private TextMeshProUGUI serialText;
    [SerializeField] private TextMeshProUGUI dateOfBirthText;
    [SerializeField] private TextMeshProUGUI sexText;
    [SerializeField] private TextMeshProUGUI natText;
    [SerializeField] private TextMeshProUGUI expiryDateText;

    // Incorrect variables
    private bool isNameRandom;
    private bool isPhotoRandom;
    private bool isDateOfBirthRandom;
    private bool isSexRandom;
    private bool isNatRandom;
    private bool isExpiryDateRandom;
    
    private void Start()
    {
        tourist = GameObject.FindGameObjectWithTag("Tourist").GetComponent<Tourist>();
        lists = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TouristListHolder>();

        if (tourist.isPassportCorrect)
        {
            SetPassportInfoCorrect();
        }
        else
        {
            SetPassportInfoIncorrect();
        }
    }

    private void SetPassportInfoCorrect()
    {
        nameText.text = tourist.name;

        if (tourist.sex == 'M')
        {
            photo.sprite = lists.maleFacesPassport[tourist.faceIndex];
        }
        else
        {
            photo.sprite = lists.femaleFacesPassport[tourist.faceIndex];
        }

        serialNumber = new string(Enumerable.Range(0, 11).Select(_ => "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[Random.Range(0, 36)]).ToArray());
        serialNumber = serialNumber.Insert(5, "-");
        serialText.text = serialNumber;

        dateOfBirthText.text = tourist.dateOfBirth;
        sexText.text = tourist.sex.ToString();
        natText.text = tourist.nationality.ToString();
        expiryDateText.text = tourist.expiryDate;
    }

    private void SetPassportInfoIncorrect()
    {
        isNameRandom = (Random.Range(0, 2) == 1);
        isPhotoRandom = (Random.Range(0, 2) == 1);
        isDateOfBirthRandom = (Random.Range(0, 2) == 1);
        isSexRandom = (Random.Range(0, 2) == 1);
        isNatRandom = (Random.Range(0, 2) == 1);
        isExpiryDateRandom = (Random.Range(0, 2) == 1);

        bool allFalse = new bool[] { isNameRandom, isPhotoRandom, isDateOfBirthRandom, isSexRandom, isNatRandom, isExpiryDateRandom }.All(b => !b);

        if (allFalse) // If nothing gets randomised, change isPassportCorrect to true
        {
            tourist.isPassportCorrect = true;
            SetPassportInfoCorrect();
            return;
        }
        else
        {
            if (isNameRandom)
            {
                if (tourist.sex == 'M')
                {
                    string firstName = lists.maleFirstNames[Random.Range(0, lists.maleFirstNames.Count)];
                    string lastName = lists.lastNames[Random.Range(0, lists.lastNames.Count)];
                    nameText.text = string.Format("{0}, {1}", lastName, firstName);
                }
                else
                {
                    string firstName = lists.femaleFirstNames[Random.Range(0, lists.femaleFirstNames.Count)];
                    string lastName = lists.lastNames[Random.Range(0, lists.lastNames.Count)];
                    nameText.text = string.Format("{0}, {1}", lastName, firstName);
                }
            }
            else
            {
                nameText.text = tourist.name;
            }

            if (isPhotoRandom)
            {
                if (tourist.sex == 'M')
                {
                    passportFaceIndex = Random.Range(0, lists.maleFacesPassport.Count);
                    photo.sprite = lists.maleFacesPassport[passportFaceIndex];
                }
                else
                {
                    Random.Range(0, lists.femaleFacesPassport.Count);
                    photo.sprite = lists.femaleFacesPassport[passportFaceIndex];
                }
            }
            else
            {
                if (tourist.sex == 'M')
                {
                    photo.sprite = lists.maleFacesPassport[tourist.faceIndex];
                }
                else
                {
                    photo.sprite = lists.femaleFacesPassport[tourist.faceIndex];
                }
            }

            if (isDateOfBirthRandom)
            {
                int day = Random.Range(1, 29);
                int month = Random.Range(1, 13);
                int year = Random.Range(1969, 2005);
                dateOfBirthText.text = string.Format("{0:D2}/{1:D2}/{2:D4}", day, month, year);
            }
            else
            {
                dateOfBirthText.text = tourist.dateOfBirth;
            }

            if (isSexRandom)
            {
                int sexNumber = Random.Range(0, 2);
                sexText.text = sexNumber == 0 ? 'M'.ToString() : 'F'.ToString();
            }
            else
            {
                sexText.text = tourist.sex.ToString();
            }

            if (isNatRandom)
            {
                nationality = (Nationality)Random.Range(0, 4);
                natText.text = nationality.ToString();
            }
            else
            {
                natText.text = tourist.nationality.ToString();
            }

            if (isExpiryDateRandom)
            {
                int day = Random.Range(1, 29);
                int month = Random.Range(1, 13);
                int year = Random.Range(2017, 2034);
                expiryDateText.text = string.Format("{0:D2}/{1:D2}/{2:D4}", day, month, year);
            }
            else
            {
                expiryDateText.text = tourist.expiryDate;
            }
        }
    }
}
