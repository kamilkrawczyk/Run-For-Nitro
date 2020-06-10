using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
    [HideInInspector]
    public float currentTime = 0.0f;

    private TextMeshProUGUI tmPRO_timer;

    private bool canGo;
  
    // Start is called before the first frame update
    void Start()
    {
        tmPRO_timer = GetComponent<TextMeshProUGUI>();
       
        currentTime = 2;
        canGo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canGo)
        {
            currentTime += Time.deltaTime;
            string minutes = Mathf.Floor((currentTime % 3600) / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            tmPRO_timer.text = minutes + ":" + seconds;
        }   
    }
    public void StartTime()
    {
        canGo = true;
    }
    public void StopTime()
    {
        canGo = false;
    }
    private void OnDestroy() //when scene changes
    {
        DataPersistence.Time = currentTime; //zapisz czas 
    }
    
}
