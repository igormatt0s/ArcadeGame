using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{
    public void iniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }

    public void sair()
    {
        Application.Quit();
    }
}
