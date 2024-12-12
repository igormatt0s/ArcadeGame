using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a classe script herda da classe MonoBehaviour por isso os :
public class scriptPc : MonoBehaviour
{
    public GameObject tiro;
    
    private Rigidbody2D rbd;
    private AudioSource som;
    public float rapidez;

    private float altura;
    private float largura;
    private float alturaNave;

    // Start is called before the first frame update
    void Start()
    {
        // referenciar o objeto PC da IDE
        rbd = this.GetComponent<Rigidbody2D>();
        som = this.GetComponent<AudioSource>();
        rapidez = 10;

        // forma correta de saber a altura e largura
        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect;

        /*SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Bounds limites = sr.bounds;
        alturaNave = limites.size.y;*/
        // OU
        alturaNave = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        // método para verificar se o usuário está apertando as teclas da esquerda ou A (valores até -1), as teclas da direita ou D (valores até 1) ou nenhuma tecla (valor 0)
        // caso não queira essa sensação de arrastar, pode pular direto para os valores -1 ou 1 com o método GetAxisRaw()
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // criar um vetor para representar a velocidade em termos vetoriais
        Vector2 vel = new Vector2();
        vel.x = x * rapidez;
        vel.y = y * rapidez;

        // propriedade para alterar a velocidade do objeto
        rbd.velocity = vel;

        // metodo alternativo simplificado
        // rbd.velocity = new Vector2(x, y) * rapidez;

        // mover o objeto de uma borda a outra de forma grosseira
        // o this. é opcional da linha 39 até a linha 53
        /*if (this.transform.position.x > 8.88)
        {
            Vector2 pos = new Vector2();
            pos.x = -8.88f; // f de float
            pos.y = this.transform.position.y;

            // propriedade para alterar a posição do objeto
            rbd.transform.position = pos;

            // metodo alternativo simplificado
            // rbd.transform.position = new Vector2(-8.88f, this.transform.position.y);
        }
        else if (this.transform.position.x < -8.88)
        {
            rbd.transform.position = new Vector2(8.88f, this.transform.position.y);
        }

        if (this.transform.position.y > 0)
            rbd.transform.position = new Vector2(this.transform.position.x, 0);
        else if (this.transform.position.y < -5)
            rbd.transform.position = new Vector2(this.transform.position.x, -5);*/

        // forma correta de utilizar a largura e altura
        if (this.transform.position.x > largura)
            rbd.transform.position = new Vector2(-largura, this.transform.position.y);
        else if (this.transform.position.x < -largura)
            rbd.transform.position = new Vector2(largura, this.transform.position.y);

        if (this.transform.position.y > 0)
            rbd.transform.position = new Vector2(this.transform.position.x, 0);
        else if (this.transform.position.y < -altura + (alturaNave / 2))
            rbd.transform.position = new Vector2(this.transform.position.x, -altura + (alturaNave / 2));

        // caso o usuário pressione a tecla espaço ou clique no botão esquerdo do mouse (botão esquerdo valor: 0, botão direito valor: 1), lança o tiro
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            som.Play();
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + (alturaNave / 2));
            Instantiate(tiro, pos, Quaternion.identity);
        }
    }
}
