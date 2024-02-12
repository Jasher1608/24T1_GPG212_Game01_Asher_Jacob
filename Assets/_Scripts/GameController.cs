using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int day;
    [SerializeField] private float dayTime;
    private float timer;

    [SerializeField] private GameObject touristPrefab;

    private bool acceptTourist;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ProcessChoice(bool accept)
    {
        acceptTourist = accept;
    }

    private void DayOneRules()
    {

    }
}
