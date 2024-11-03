using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FelpudoFlappy : MonoBehaviour
{
    public float forcaPulo = 5f;
    public GameObject prefabProjetil;
    public Transform pontoSpawnProjetil;
    public float velocidadeProjetil = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        GameObject projetil = Instantiate(prefabProjetil, pontoSpawnProjetil.position, Quaternion.identity);
        Rigidbody2D rbProjetil = projetil.GetComponent<Rigidbody2D>();
        rbProjetil.velocity = Vector2.right * velocidadeProjetil;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            CarregarCena("Lose"); 
        }
        else if (collision.gameObject.CompareTag("Uruca"))
        {
            CarregarCena("Game2"); 
        }
    }

    void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
}
