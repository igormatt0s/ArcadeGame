using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptControladorJogo : MonoBehaviour
{
    private bool pausa;
    // Start is called before the first frame update
    void Start()
    {
        pausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ao pressionar a tecla ESC
        {
            if (pausa)
            {
                Time.timeScale = 1; // despausa
                SceneManager.UnloadSceneAsync(0); // remove o Menu
            }
            else
            {
                Time.timeScale = 0; // pausa
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive); // carrega o Menu
            }

            pausa = !pausa;
        }
    }
}
