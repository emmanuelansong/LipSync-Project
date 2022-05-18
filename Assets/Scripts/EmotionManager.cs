using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Emotion
{
    public string name;
    //public bool activated;
    
    [Range(0.0f, 100.0f)]
    public float value;
}
public class EmotionManager : MonoBehaviour
{
    public Emotion[] emotion;
    public LipSyncFromAudioFile lip;
    public float sliderValue;
    public GameObject panel;

    // Start is called before the first frame update

    void Start()
    {
        GetComponentInChildren<Slider>().wholeNumbers = true;
        gameObject.GetComponentInChildren<Slider>().maxValue = 100;
        sliderValue = GetComponentInChildren<Slider>().value;

        lip = GameObject.Find("LipSync_Character").GetComponent<LipSyncFromAudioFile>();

        for (int x = 0; x < emotion.Length; x++)
        {
            emotion[x].name = gameObject.name;
            emotion[x].value = 0;
        }
    }

    //menu sliders
    private void Update()
    {
        
        GetComponent<Text>().text = $"{gameObject.name} : {sliderValue}%";
        sliderValue = GetComponentInChildren<Slider>().value;

        for (int x = 0; x < emotion.Length; x++)
        {
            if (emotion[x].name == gameObject.name)
            {
                emotion[x].value = sliderValue;
            }
        }
        Emotion(emotion);

    }

    //emotion list
    void Emotion(Emotion[] emotion)
    {
        for (int x = 0; x < emotion.Length; x++)
        {
            switch (emotion[x].name)
            {

                case "Happy":

                    if (emotion[x].value > 0)
                    {
                        lip.HappyPreset(emotion[x].value);
                    }
                    break;

                case "Sad":
                    if (emotion[x].value > 0)
                    {
                        lip.SadPreset(emotion[x].value);
                    }
                    break;
                case "Surprised":
                    if (emotion[x].value > 0)
                    {
                        lip.SurprisedPreset(emotion[x].value);
                    }
                    break;

                case "Scared":
                    if (emotion[x].value > 0)
                    {
                        lip.ScaredPreset(emotion[x].value);
                    }
                    break;
                case "Angry":
                    if (emotion[x].value > 0)
                    {
                        lip.AngryPreset(emotion[x].value);

                    }
                    break;
                case "Disgusted":
                    if (emotion[x].value > 0)
                    {
                        lip.DisgustPreset(emotion[x].value);
                    }
                    break;

                case "Contempt":
                    if (emotion[x].value > 0)
                    {
                        lip.ContemptPreset(emotion[x].value);
                    }
                    break;
            }
        }
    }
}
