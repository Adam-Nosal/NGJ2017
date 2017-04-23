using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource musicTheme;
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
        src.clip = clips[0];
        src.Play();
        yield return new WaitForSeconds(clips[0].length);
        cthulu.SetActive(true);
        src.clip = clips[1];
        src.Play();
        fader.SetActive(true);
        yield return new WaitForSeconds(clips[1].length);
        src.clip = clips[2];
        src.Play();
        yield return new WaitForSeconds(clips[2].length);
        src.clip = clips[3];
        src.Play();
        yield return new WaitForSeconds(clips[3].length);

        musicTheme.Stop();
        SceneManager.LoadScene("main");
    }
}

