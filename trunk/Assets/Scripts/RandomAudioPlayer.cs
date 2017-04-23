using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour {

  


    [Header("Audio")]
    [SerializeField] private AudioSource source;
    [SerializeField] private float MinSoundTimestamp= 2.5f;
    [SerializeField] private float MaxSoundTimestamp= 5.0f;
    private float lastSoundTimestamp = 0.0f;
    private float lastSoundRandomOffset = 2.5f;
    private bool canPLay = true;

    [SerializeField] private AudioClip[] audioClips;


    void Awake()
    {
        source.loop = false;
        source.playOnAwake = false;
        lastSoundRandomOffset = MaxSoundTimestamp - MinSoundTimestamp;
        
    }

    private void PlaySound()
    {
        int index = Random.Range(0, audioClips.Length);
        source.clip = audioClips[index];
        source.Play();
    }

     void Update()
    {
        if(lastSoundRandomOffset < Time.time && canPLay)
        {
            PlaySound();
            canPLay = false;
        }
        if (lastSoundRandomOffset < Time.time && source.isPlaying == false)
        {
            lastSoundRandomOffset = Time.time + Random.Range(0, MaxSoundTimestamp - MinSoundTimestamp);
            canPLay = true;
        }
        
    }

}
