using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneProcesser : MonoBehaviour
{
    private void Start() 
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start(Microphone.devices[0], true, 1, 44100);
        audio.loop = true;
        while(!(Microphone.GetPosition(null) > 0))
        {
            audio.Play();
        }
    }
}

