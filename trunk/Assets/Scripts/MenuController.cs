using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    public Dropdown microphoneMenu;

    private void Start()
    {
        microphoneMenu.ClearOptions();
        microphoneMenu.AddOptions(new List<string>(Microphone.devices));
        microphoneMenu.onValueChanged.AddListener((int i) =>
            {
                Knot.Instance.micIdx = i;
            });
    }

    public void RunGame()
    {
        SceneManager.LoadScene("main");
    }
}

