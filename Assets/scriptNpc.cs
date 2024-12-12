using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNpc : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float rapidez = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ACERTOU!");
        scriptPlacar.addPlacar(5);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rbd = this.GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, -rapidez);
    }

    // Update is called once per frame
    void Update()
    {
        // Auto destruir
        if(transform.position.y < -Camera.main.orthographicSize)
        {
            //Destroy(this.gameObject);
            Destroy(gameObject);
        }
    }
}
