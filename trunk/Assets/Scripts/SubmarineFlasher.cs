using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineFlasher : MonoBehaviour {

    [SerializeField] private Image Submarine;
    [SerializeField] private float frequencyPerSecond = 20;
    private float timeOffset;
    private float timeCounter;

    private void Awake()
    {
        timeCounter = Time.time;
        timeOffset = 1/ frequencyPerSecond;
    }

    private void Update()
    {
        if(Time.time > timeCounter + timeOffset)
        {
            Submarine.enabled = !Submarine.enabled;
            timeCounter = Time.time;
        }
    }
}
