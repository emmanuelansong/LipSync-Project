using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class ButtonManager : MonoBehaviour
{
    public PlayableDirector pb;
    
    public AudioSource placeholderAudioSource;
    public LipSyncFromAudioFile lipsync;
    public TextAsset SSML;
    float timeDelay = 2;
    // Start is called before the first frame update
    void Start()
    {
        
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.text = pb.name;

        

    }

    // Update is called once per frame
    void Update()
    {
        //fast forward/backtrack
        if (pb.time > 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pb.time += 1;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pb.time -= 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            pb.Stop();
            pb.Play();
            Debug.Log("Play..");
        }

        if (pb.time > 0)
        {

            foreach (var x in lipsync.visemes)
            {
                if ((pb.time * 1000) > (x.Key - lipsync.offset) && (pb.time * 1000) < (x.Key + lipsync.offset))
                {
                    //method to get blendshapes + display them
                    StartCoroutine(lipsync.test(x.Value, x.Key));

                    //brow movement for immersion
                    //StartCoroutine(lipsync.BrowMovement(x.Key));
                    

                }
            }
            
        }
        
        timeDelay-=Time.deltaTime;
   
        if (timeDelay <= 0)
        {
            StartCoroutine(lipsync.BrowMovement());
            timeDelay = Random.Range(1, 5);
        }

    }
    private void OnDrawGizmos()
    {
        //editor stuff
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.text = pb.name;
    }

    //on click method
    public void PlayTimeline()
    {
        string path = null;
        if (gameObject.name == "audio1")
        {
            
            path = Application.dataPath + "/Resources/walter_placeholder";
        }

        if (gameObject.name == "audio2")
        {
            path = Application.dataPath + "/Resources/walter_placeholder_2";
        }
        //if there is a key/region
        if (lipsync.key != null && lipsync.region != null)
        {
            Transform Panel = transform.parent;
            //read SSML, get visemes, output to WAV file.
            lipsync.FromFile_Viseme(placeholderAudioSource, SSML.text, path);

            foreach(Transform x in Panel.transform)
            {
                //stop all timelines
                x.GetComponent<ButtonManager>().pb.Stop();
            }
            
            //play timeline related to button
            pb.Play();
            

        }

        
    }
}


