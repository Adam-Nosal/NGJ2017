using UnityEngine;

public class Knot : MonoBehaviour
{
    public static Knot instance { get; private set; }

    public int micIdx = 0;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}

