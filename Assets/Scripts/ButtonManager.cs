using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class ButtonManager : MonoBehaviour
{
    public PlayableDirector pb;
    public AudioSource audioSource;
    public LipSyncFromAudioFile lipsync;
    // Start is called before the first frame update
    void Start()
    {
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.text = pb.name;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDrawGizmos()
    {
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.text = pb.name;
    }

    public void PlayTimeline()
    {
        if (lipsync.key != null && lipsync.region != null)
        {
            lipsync.FromFile_Viseme(audioSource);
            pb.Stop();
            pb.Play();
        }
    }
}
