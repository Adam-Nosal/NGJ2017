using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicThemePlayer : MonoBehaviour {
    private bool canPLay = true;

    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource source;

    private void Awake()
    {
        source.loop = false;
        source.playOnAwake = false;
    }
    
    private void PlaySound()
    {
        int index = Random.Range(0, audioClips.Length);
        source.clip = audioClips[index];
        source.Play();
    }


    private void Update()
    {
        canPLay = !source.isPlaying;


        if (canPLay)
        {
            PlaySound();
        }
    }
}
