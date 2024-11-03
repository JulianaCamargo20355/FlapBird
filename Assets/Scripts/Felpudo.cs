using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importa o namespace do TextMesh Pro

public class FelpudoCena2 : MonoBehaviour
{
    public float forcaPulo = 5f;
    public GameObject prefabProjetil;
    public Transform pontoSpawnProjetil;
    public float velocidadeProjetil = 10f;
    public float tempoLimite = 30f;
    public TextMeshProUGUI textoContagemRegressiva; 

    private Rigidbody2D rb;
    private float tempoRestante;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempoRestante = tempoLimite;
    }

    void Update()
    {
        ContarTempo();

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

    void ContarTempo()
    {
        tempoRestante -= Time.deltaTime;

        if (tempoRestante <= 0)
        {
            CarregarCenaLose();
        }

        if (textoContagemRegressiva != null)
        {
            textoContagemRegressiva.text = "00:" + Mathf.Max(0, Mathf.Ceil(tempoRestante)).ToString() + "s";
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
            CarregarCenaLose(); 
        }
    }

    void CarregarCenaLose()
    {
        SceneManager.LoadScene("Lose");
    }
}
