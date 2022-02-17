using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class EmotionManager : MonoBehaviour
{

    LipSyncFromAudioFile lip;
    public float sliderValue;
    // Start is called before the first frame update
    //public Emotion[] emotion;
    void Start()
    {
        GetComponentInChildren<Slider>().wholeNumbers = false;
        gameObject.GetComponentInChildren<Slider>().maxValue = 100;
        sliderValue = GetComponentInChildren<Slider>().value;
        lip = GameObject.Find("LipSync_Character").GetComponent<LipSyncFromAudioFile>();

    }

    private void Update()
    {
        sliderValue = GetComponentInChildren<Slider>().value;
        //change text
        var text = GetComponent<Text>().text = $"{gameObject.name} : {Mathf.Round(sliderValue * 100) / 100}";
        //ChangeValue();

        for (int x = 0; x < lip.emotion.Length; x++)
        {
            if (lip.emotion[x].name == gameObject.name)
                lip.emotion[x].value = sliderValue;

        }


    }
}
