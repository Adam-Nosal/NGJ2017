using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour {

    [SerializeField] private RectTransform mTransform;

    [SerializeField] private float rotationRangeMin;
    [SerializeField] private float rotationRangeMax;
    [SerializeField] private int ActivityMatter = 10;
    private int activityIterator;
    [SerializeField] private float ActivityForce = 25.0f;

     void Awake()
    {
        mTransform = this.GetComponent<RectTransform>();
    }


     void Update()
    {
        activityIterator++;
        if (activityIterator > ActivityMatter)
        {
            activityIterator = 0;
            float actualRotation = mTransform.localRotation.eulerAngles.z;
            float diff = Mathf.PerlinNoise(Time.time, 1) * ActivityForce;

            if(Random.Range(0,10)>=5)
                 actualRotation += diff;
            else
                actualRotation -= diff;

            actualRotation = Mathf.Min(rotationRangeMin, actualRotation);
            actualRotation = Mathf.Max(actualRotation, rotationRangeMax);

            mTransform.rotation = Quaternion.Euler(0f, 0f, actualRotation);
            
        }
    }

}
