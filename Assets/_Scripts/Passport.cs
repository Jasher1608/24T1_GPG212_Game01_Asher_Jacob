using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class Passport : MonoBehaviour
{
    private Tourist tourist;
    private TouristListHolder lists;
    
    private TextMeshProUGUI nameText;
    private Image photo;
    private string serialNumber;
    private TextMeshProUGUI serialText;
    private TextMeshProUGUI dateOfBirthText;
    private TextMeshProUGUI sexText;
    private TextMeshProUGUI natText;
    private TextMeshProUGUI expiryDateText;
    
    private void Start()
    {
        tourist = GameObject.FindGameObjectWithTag("Tourist").GetComponent<Tourist>();
        lists = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TouristListHolder>();
    }

    private void SetPassportInfo()
    {
        if (tourist.isPassportCorrect)
        {
            nameText.text = tourist.name;
            // Photo
            if (tourist.sex == 'M')
            {
                photo.sprite = lists.maleFacesPassport[tourist.faceIndex];
            }
            else
            {
                photo.sprite = lists.femaleFacesPassport[tourist.faceIndex];
            }

            // Serial text here
            serialNumber = new string(Enumerable.Range(0, 11).Select(_ => "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[Random.Range(0, 36)]).ToArray());
            serialNumber = serialNumber.Insert(5, "-");
            serialText.text = serialNumber;

            dateOfBirthText.text = tourist.dateOfBirth;
            sexText.text = tourist.sex.ToString();
            natText.text = tourist.nationality.ToString();
            expiryDateText.text = tourist.expiryDate;
        }
        else
        {

        }
    }
}
