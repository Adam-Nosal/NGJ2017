using UnityEngine.EventSystems;
using UnityEngine;

public class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(EventSystem.current.IsPointerOverGameObject());
        }
	}
}
