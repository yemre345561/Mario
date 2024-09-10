using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitApp()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }

}
