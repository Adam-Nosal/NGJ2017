using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRotation : MonoBehaviour {

    [SerializeField] private Transform FollowTransform;
    [SerializeField] private Transform mTransform;
    [SerializeField] private float ActivityForce = 5;


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
        if(mTransform==null)
        mTransform = this.GetComponent<Transform>();
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


        float actualRotation = mTransform.localRotation.eulerAngles.z;
            float diff = Mathf.PerlinNoise(Time.time, 1) * ActivityForce;
        if (Random.Range(0, 10) >= 5)
            actualRotation += diff;
        else
            actualRotation -= diff;


        mTransform.rotation = Quaternion.Euler(0f, 0f, actualRotation);

        if (FollowTransform != null)
        {
            this.transform.position = FollowTransform.position;
        }
        
    }

}
