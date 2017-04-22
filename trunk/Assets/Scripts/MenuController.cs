using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Dropdown microphoneMenu;
    public GameObject cthulu, fader;

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
        yield return new WaitForSeconds(0.5f);
        cthulu.SetActive(true);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("main");
    }
}

