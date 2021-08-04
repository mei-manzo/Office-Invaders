using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class EnemyAudioController : MonoBehaviour { 

    [SerializeField] AudioClip[] clips;
    [SerializeField] float delayBetweenClips;
    bool canPlay;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        canPlay = true;
        print("Got sound component");
    }
    public void Play()
    {

        if (!canPlay)
            return;
        GameManager.Instance.Timer.Add(() =>
        {
            canPlay = true;

        }, delayBetweenClips);
        canPlay = false;
        int clipIndex = Random.Range(0, clips.Length);


        AudioClip clip = clips[clipIndex];



        source.PlayOneShot(clip);

    }
    // Update is called once per frame

}
