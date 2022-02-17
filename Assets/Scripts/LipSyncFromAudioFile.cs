using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using UnityEditor;
using UnityEngine.Playables;
using UnityEngine.UI;
[Serializable]
public class Emotion
{
    public string name;
    //public bool activated;

    [Range(0.0f, 100.0f)]
    public float value;
}

public class LipSyncFromAudioFile : MonoBehaviour
{
    // Start is called before the first frame update

    SpeechConfig speechConfig;
    AudioConfig audioConfig;

    [TextArea(15, 20)]
    public string XML;

    public string key;
    public string region;

    public InputField keyInput;
    public InputField regionInput;
    

    public AudioSource source;
    public AudioSource placeholderSource;

    public int offset;
    float timeDelay;
    public Dictionary<float, int> visemes;

    public Emotion[] emotion;
    [TextArea(15, 20)]
    public string text;
    public PlayableDirector pb;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public SkinnedMeshRenderer eyelashRenderer;

    ButtonManager bm;
    void Start()
    {
        keyInput.text = key;
        regionInput.text = region;
        visemes = new Dictionary<float, int>();


        //FromFile_Viseme();
        timeDelay = UnityEngine.Random.Range(1, 10);
        //FromFile_Viseme_XML(placeholderSource);
    }

    void GetBlendshape(int value, int id)
    {
        string viseme = null;
        //get each viseme recorded

        string visemeIdentifier = "Genesis8_1Male__facs_ctrl_v";
        if (id == 0)
        {
            viseme = "null";

            for (int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
            {
                if(skinnedMeshRenderer.sharedMesh.GetBlendShapeName(i).Contains(visemeIdentifier))
                { 
                    skinnedMeshRenderer.SetBlendShapeWeight(i, 0);
                    
                }
            }
        }


        if (id == 1)
        {
            viseme = "AA"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);
        }
        if (id == 2)
        {
            viseme = "AA"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);

        }
        if (id == 3)
        {
            viseme = "OW"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            
        }
        if (id == 4)
        {
            viseme = "EE"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);

        }
        if (id == 5)
        {
            viseme = "ER"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
        }
        if (id == 6)
        {
            viseme = "EE"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);
        }
        if (id == 7)
        {
            viseme = "W"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            
        }
        if (id == 8)
        {
            viseme = "EH"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
        }
        if (id == 9)
        {
            viseme = "OW"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            
        }
        if (id == 10)
        {
            viseme = "OW"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            
        }
        if (id == 11)
        {
            viseme = "IY"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);
        }
        if (id == 12)
        {
            viseme = "IH"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);
        }
        if (id == 13)
        {
            viseme = "OW"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
           
        }
        if (id == 14)
        {
            viseme = "L"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
        }
        if (id == 15)
        {
            viseme = "S"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);
        }
        if (id == 16)
        {
            viseme = "SH"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
        }
        if (id == 17)
        {
            viseme = "TH"; skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);

        }
        if (id == 18)
        {
            viseme = "F";
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("CheekSquint", "Genesis8_1Male__facs_ctrl_"), value);
        }
        if (id == 19)
        {
            viseme = "T";
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
        }
        if (id == 20)
        {
            viseme = "K";
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
        }
        if (id == 21)
        {
            viseme = "M";
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo(viseme, visemeIdentifier), value);
            

        }

    }
        
    int ConvertTo(string viseme, string identifier)
    {
        int output = 0;
        for(int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
        {
            var name = skinnedMeshRenderer.sharedMesh.GetBlendShapeName(i);
            if (name.Contains(identifier))
            {
                if (name.Contains(viseme))
                {
                    //Debug.Log(viseme);
                    output = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(name);
                    return output;
                }
            }

        }
        return output;
    }

    int ConvertTo_Eye(string viseme, string identifier)
    {
        int output = 0;
        for (int i = 0; i < eyelashRenderer.sharedMesh.blendShapeCount; i++)
        {
            var name = eyelashRenderer.sharedMesh.GetBlendShapeName(i);
            if (name.Contains(identifier))
            {
                if (name.Contains(viseme))
                {
                    //Debug.Log(viseme);
                    output = eyelashRenderer.sharedMesh.GetBlendShapeIndex(name);
                    return output;
                }
            }

        }
        return output;
    }

    // Update is called once per frame
    void Update()
    {
        timeDelay -= Time.deltaTime;

        key = keyInput.text;
        region = regionInput.text;
        Emotion(emotion);
        if (Input.GetKeyDown(KeyCode.K))
        {
            //source.Stop();
            //source.Play();
            pb.Stop();
            pb.Play();
            Debug.Log("Play..");
        }
        if (source.time > 0 || pb.time > 0)
        {

            foreach (var x in visemes)
            {
                
                if ((pb.time * 1000) > (x.Key - offset) && (pb.time * 1000) < (x.Key + offset))
                {

                    StartCoroutine(test(x.Value, x.Key));
                    StartCoroutine(BrowMovement(x.Key));

                }
                //Debug.Log(x.Key);

            }
        }
        if(timeDelay <= 0f)
        {
            StartCoroutine(blink());
        }
        

    }
    IEnumerator blink()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("EyeBlink", "Genesis8_1Male__facs_ctrl_"), 0);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("EyeBlink","Genesis8_1MaleEyelashes__facs_ctrl_"), 0);

        yield return  new WaitForSeconds(timeDelay);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("EyeBlink", "Genesis8_1Male__facs_ctrl_"), 100);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("EyeBlink", "Genesis8_1MaleEyelashes__facs_ctrl_"), 100);

        //Debug.Log("blinking...");

        yield return new WaitForSeconds(0.3f);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("EyeBlink", "Genesis8_1Male__facs_ctrl_"), 0);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("EyeBlink", "Genesis8_1MaleEyelashes__facs_ctrl_"), 0);

        timeDelay = UnityEngine.Random.Range(1, 10);
        //Debug.Log("blink ended.");
    }

    IEnumerator test(int id, float key)
    {
        var duration = (key+offset) - (key-offset);
        GetBlendshape(100, id);
        yield return new WaitForSeconds(duration/1000);
        GetBlendshape(0, id);
    }
    IEnumerator BrowMovement(float key)
    {
        float value = UnityEngine.Random.Range(50, 100);

        float activate0 = UnityEngine.Random.Range(0, 1);
        int activate = UnityEngine.Random.Range(0, 3);
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        var duration = (key + offset) - (key - offset);

        if (activate0 > 0.05f)
        {
            yield break;
        }

        if (activate0 < 0.05)
        {
            
            if (activate == 1)
                skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowUp", identifier), value);
            if (activate == 2)
                skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowDown", identifier), value);
        }
        yield return new WaitForSeconds(duration);

        if (activate == 1)
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowUp", identifier), 0);
        if (activate == 2)
            skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowDown", identifier), 0);
        

    }
    void Emotion(Emotion[] emotion )
    {
        //string identifier = "Genesis8_1__facs_ctrl_";
        foreach(var x in emotion )
        {
            
            switch (x.name)
            {
                
                case "Happy":

                    if (x.value > 0)
                    {
                        HappyPreset(x.value);
                    }
                    
                        //skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("SmileFullFace", identifier), 0);
                    
                    break;

                case "Sad":
                    if (x.value > 0)
                    {
                        SadPreset(x.value);
                    }
                    else
                    {
                        
                    }
                    
                    break;
                case "Surprised":
                    if (x.value > 0)
                    {
                        SurprisedPreset(x.value);                   
                    }
                    break;

                case "Scared":
                    if (x.value > 0)
                    {
                        ScaredPreset(x.value);
                    }
                    else
                    {
                        
                    }
                    
                    break;
                case "Angry":
                    if (x.value > 0)
                    {
                        AngryPreset(x.value);
                        
                    }
                    
                    else
                    {
                        
                    }
                    
                    break;
                case "Disgust":
                    if (x.value > 0)
                    {
                        DisgustPreset(x.value);
                    }
                    else
                    {
                       
                    }
                    
                    break;

                case "Contempt":
                    if (x.value > 0)
                    {
                        ContemptPreset(x.value);
                    }
                    else
                    {
                        break;

                    }
                    break;
            }
        }
    }
    void HappyPreset(float value)
    {
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("MouthSmile", identifier), value/2);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowUp", identifier), value);

        string eye_identifier = "Genesis8_1MaleEyelashes__facs_ctrl_";
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("BrowUp", eye_identifier), value);
    }

    void SadPreset(float value)
    {
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowInnerUp", identifier), value);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("MouthFrown", identifier), value/2);

        string eye_identifier = "Genesis8_1MaleEyelashes__facs_ctrl_";
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("BrowInnerUp", eye_identifier), value);

    }

    void SurprisedPreset(float value)
    {
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowUp", identifier), value);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("EyeWide", identifier), value);

        //eye stuff
        string eye_identifier = "Genesis8_1MaleEyelashes__facs_ctrl_";
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("BrowUp", eye_identifier), value);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("EyeWide", eye_identifier), value);

    }

    void ScaredPreset(float value)
    {
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowInnerUp", identifier), value);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowDown", identifier), value);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("MouthLowerDown", identifier), value);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("MouthFrown", identifier), value);

        //eye stuff
        string eye_identifier = "Genesis8_1MaleEyelashes__facs_ctrl_";
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("BrowInnerUp", eye_identifier), value);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("BrowDown", eye_identifier), value);
        
    }

    void AngryPreset(float value)
    {
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("Frown", identifier), value/2);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("BrowDown", identifier), value);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("EyeSquint", identifier), value);
        
        //eye stuff
        string eye_identifier = "Genesis8_1MaleEyelashes__facs_ctrl_";
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("Frown", eye_identifier), value/2);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("BrowDown", eye_identifier), value);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("EyeSquint", eye_identifier), value);

    }

    void DisgustPreset(float value)
    {
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("Frown", identifier), value/2);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("NoseSneer", identifier), value);
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("EyeSquint", identifier), value);

        //eye stuff
        string eye_identifier = "Genesis8_1MaleEyelashes__facs_ctrl_";
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("Frown", eye_identifier), value / 2);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("NoseSneer", eye_identifier), value / 2);
        eyelashRenderer.SetBlendShapeWeight(ConvertTo_Eye("EyeSquint", eye_identifier), value / 2);

    }

    void ContemptPreset(float value)
    {
        
        string identifier = "Genesis8_1Male__facs_ctrl_";
        skinnedMeshRenderer.SetBlendShapeWeight(ConvertTo("MouthDimple", identifier), value/2);
    }


    public void FromFile_Viseme(AudioSource audioSource, string SSML)
    {
        //write to new file
        speechConfig = SpeechConfig.FromSubscription(key, region);
        speechConfig.SpeechSynthesisVoiceName = "en-US-GuyNeural";
        var audioConfig = AudioConfig.FromWavFileInput(AssetDatabase.GetAssetPath(audioSource.clip));

        using (var synthesizer = new SpeechSynthesizer(speechConfig, audioConfig))
        {
            synthesizer.SynthesisStarted += (s, e) =>
            {
                Debug.Log("\nSession started event.");//
            };
            //on receiving viseme
            synthesizer.VisemeReceived += (s, e) =>
            {
                visemes.Add(Convert.ToSingle(e.AudioOffset / 10000), Convert.ToInt32(e.VisemeId));
                Debug.Log(e.VisemeId);
            };

            synthesizer.Synthesizing += (s, e) =>
            {
                return;
            };

            //get result
            var result = synthesizer.SpeakSsmlAsync(SSML);
            
            //if synthesis completed
            if (result.Result.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                Debug.Log($"Viseme Speech synthesized to speaker for text ");

            }

            //if cancelled
            else if (result.Result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result.Result);
                Debug.Log($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Debug.Log($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Debug.Log($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                    Debug.Log($"CANCELED: Did you update the subscription info?");
                }

            }


            synthesizer.SynthesisCompleted += (s, e) =>
            {
                Debug.Log("\nSession stopped event.");
                Debug.Log("\nStop recognition.");
            };
            
        };


    }

    public void FromFile_Viseme_XML(AudioSource audioSource)
    {
        //write to new file
        speechConfig = SpeechConfig.FromSubscription(key, region);
        
        var audioConfig = AudioConfig.FromWavFileOutput(AssetDatabase.GetAssetPath(audioSource.clip));

        using (var synthesizer = new SpeechSynthesizer(speechConfig, audioConfig))
        {
            synthesizer.SynthesisStarted += (s, e) =>
            {
                Debug.Log("\nSession started event.");
            };
            //on receiving viseme
            synthesizer.VisemeReceived += (s, e) =>
            {
                visemes.Add(Convert.ToSingle(e.AudioOffset / 10000), Convert.ToInt32(e.VisemeId));

            };

            synthesizer.Synthesizing += (s, e) =>
            {
                Debug.Log("synthesising..");
            };

            //get result
            var result = synthesizer.SpeakSsmlAsync(XML);

            //if synthesis completed
            if (result.Result.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                Debug.Log($"Viseme Speech synthesized to speaker for text ");

            }

            //if cancelled
            else if (result.Result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result.Result);
                Debug.Log($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Debug.Log($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Debug.Log($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                    Debug.Log($"CANCELED: Did you update the subscription info?");
                }

            }


            synthesizer.SynthesisCompleted += (s, e) =>
            {
                Debug.Log("\nSession stopped event.");
                Debug.Log("\nStop recognition.");



            };

        };


    }

}
