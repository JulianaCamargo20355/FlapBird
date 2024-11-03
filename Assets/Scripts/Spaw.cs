using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public float initialDelay = 1f;
    public float enemyPeriod = 2f;
    public float enemyHeightRange = 3f;

    void Start()
    {
        InvokeRepeating("CriarInimigo", initialDelay, enemyPeriod);
    }

    void CriarInimigo() //spawm do prefab
    {
        float randomHeight = Random.Range(-enemyHeightRange, enemyHeightRange);
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomHeight, 0);
        Instantiate(inimigoPrefab, spawnPosition, Quaternion.identity);
    }
}
