using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesmas : MonoBehaviour
{
    public static int cont = 0;
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            cont++;
            Debug.Log("Inimigo destruído! Total: " + cont);
        }
    }
}
