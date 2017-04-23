using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Dropdown microphoneMenu;
    public GameObject cthulu, fader;
    public AudioSource src;
    public AudioClip[] clips;

    private void Start()
    {
//        microphoneMenu.ClearOptions();
//        microphoneMenu.AddOptions(new List<string>(Microphone.devices));
//        microphoneMenu.onValueChanged.AddListener((int i) =>
//            {
//                Knot.Instance.micIdx = i;
//            });
    }

    public void RunGame()
    {
        StartCoroutine(RunGameAsync());

    }

    private IEnumerator RunGameAsync()
    {
        fader.SetActive(true);
        src.clip = clips[0];
        src.Play();
        yield return new WaitForSeconds(0.5f);
        cthulu.SetActive(true);
        src.clip = clips[1];
        src.Play();
        yield return new WaitForSeconds(0.5f);
        src.clip = clips[2];
        src.Play();
        yield return new WaitForSeconds(0.5f);
        src.clip = clips[3];
        src.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("main");
    }
}

