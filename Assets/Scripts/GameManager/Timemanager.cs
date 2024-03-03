using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timemanager : MonoBehaviour
{
    public static Timemanager Instance { get; private set; }


    [SerializeField] TextMeshProUGUI timerText;
    float tiempoTranscurrido;

    void Update()
    {
        if(timerText.text != "15:00")
        { 
            tiempoTranscurrido += Time.deltaTime;
            int minutes = Mathf.FloorToInt(tiempoTranscurrido / 60);
            int seconds = Mathf.FloorToInt(tiempoTranscurrido % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
       
    }
}
