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

    Transform Panel;
    // Start is called before the first frame update
    void Start()
    {
        
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.text = pb.name;

        Panel = transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        /* if (pb.time > 0)
         {
             gameObject.GetComponent<Button>().interactable = false;
         }
         else
             gameObject.GetComponent<Button>().interactable = true;*/

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
    }
    private void OnDrawGizmos()
    {
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.text = pb.name;
    }

    //on click
    public void PlayTimeline()
    {
        if (lipsync.key != null && lipsync.region != null)
        {
            lipsync.FromFile_Viseme(placeholderAudioSource, SSML.text);

            foreach(Transform x in Panel.transform)
            {
                x.GetComponent<ButtonManager>().pb.Stop();
            }
            
            pb.Play();
            

        }
    }
}


