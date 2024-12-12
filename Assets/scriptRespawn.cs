using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptRespawn : MonoBehaviour
{
    public GameObject inimigo;
    private float largura;

    // Start is called before the first frame update
    void Start()
    {
        // forma correta de saber a largura
        largura = Camera.main.orthographicSize * Camera.main.aspect;

        // Criar um inimigo
        InvokeRepeating("respawnar", 0, 1); // executa o método respawnar() começando no segundo 0 a cada 1s
    }

    private void respawnar()
    {
        // Instanciando objeto inimigo no meio da tela
        // Vector2 pos = new Vector2(0, 5);
        // Instanciando objeto inimigo em posições aleatórias
        float posX = Random.Range(-largura, largura);
        Vector2 pos = new Vector2(posX, 5);
        Instantiate(inimigo, pos, Quaternion.identity); // Quaternion.identity: rotação 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
