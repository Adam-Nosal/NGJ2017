using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private GameObject last, now;
    private Dictionary<GameObject, List<GameObject>> edges;
    private List<GameObject> vertices;
    private float time;

    public void Setup(List<GameObject> vertices, Dictionary<GameObject, List<GameObject>> edges, GameObject start)
    {
        transform.position = start.transform.position + new Vector3(0, 0, -1);
        now = start;
        this.vertices = vertices;
        this.edges = edges;

        GetComponent<Animator>().speed = 0.4f; //Random.Range(0.8f, 1.2f);
    }

    private void Move()
    {
        if(edges[now].Count > 0)
        {
            if(edges[now].Count == 1)
            {
                last = now;
                now = edges[now][0];

            }
            else
            {
                int i = Random.Range(0, edges[now].Count);
                while(edges[now][i] == last)
                {
                    i = (i + 1) % edges[now].Count;
                }
                last = now;
                now = edges[last][i];
            }
            transform.position = now.transform.position + new Vector3(0, 0, -1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Sub")
        {
            SceneManager.LoadScene("end");
        }
    }
}
