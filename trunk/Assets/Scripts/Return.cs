using UnityEngine.SceneManagement;
using UnityEngine;

public class Return : MonoBehaviour {
    public void Execute()
    {
        SceneManager.LoadScene("settings");
    }
}
