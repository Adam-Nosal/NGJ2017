using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> {

    [SerializeField] private AudioClip[] death;
    [SerializeField] public AudioClip doors;


    public AudioClip GetDeathSound()
    {
        int index = Random.Range(0, death.Length);
        return death[index];
    }
    // Update is called once per frame
    void Update () {
		
	}
}
