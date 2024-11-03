using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Uruca : MonoBehaviour
{
    public float velocidadeMovimento = 2f;
    public float alcanceMovimento = 3f;
    public int maximoTiros = 10;

    private int contadorTiros = 0;
    private Vector2 posicaoInicial;
    private bool movendoParaCima = true;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        MoverVertical();
    }

    void MoverVertical()
    {
        if (movendoParaCima)
        {
            transform.Translate(Vector2.up * velocidadeMovimento * Time.deltaTime);
            if (transform.position.y >= posicaoInicial.y + alcanceMovimento)
                movendoParaCima = false;
        }
        else
        {
            transform.Translate(Vector2.down * velocidadeMovimento * Time.deltaTime);
            if (transform.position.y <= posicaoInicial.y - alcanceMovimento)
                movendoParaCima = true;
        }
    }

    public void ReceberDano()
    {
        contadorTiros++;

        if (contadorTiros >= maximoTiros)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Bala"))
        {
            ReceberDano();
            Destroy(colisao.gameObject);
        }
    }
}
