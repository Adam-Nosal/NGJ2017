using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public float delay;
    private bool isEnabled = true;
    protected int roomCode;

    protected virtual void Update()
    {
        if(Input.GetMouseButtonDown(0) && isEnabled)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.transform.gameObject == gameObject)
            {
                Interact();
                StartCoroutine(DisableForSeconds(delay));
            }
        }
    }

    protected virtual void Interact()
    {
    }

    public IEnumerator DisableForSeconds(float delay)
    {
        isEnabled = false;
        yield return new WaitForSeconds(delay);
        isEnabled = true;
    }

    public void InRoom(int roomCode)
    {
        this.roomCode = roomCode;
    }
}
