using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieScript : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    float timer = 0;
    float spawnTime = 5;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Instantiate(zombie, transform.position, transform.rotation);
            timer = 0;
            spawnTime = Random.Range(3, 10);
        }
    }
}
