using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptPlacar : MonoBehaviour
{
    private static int placar;
    private static GameObject texto;
    // Start is called before the first frame update

    public void Start()
    {
        placar = 0;
        texto = GameObject.Find("txtPlacar"); // encontra o objeto txtPlacar
    }

    public static void addPlacar(int a)
    {
        placar += a;
        texto.GetComponent<TMP_Text>().text = "Placar: " + placar;
    }
}
