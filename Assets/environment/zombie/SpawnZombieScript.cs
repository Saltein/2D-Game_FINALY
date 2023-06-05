using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieScript : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    float timer = 0;
    float spawnTime = 1;
    void Update()
    {
        if (!Day_Night_Change.IsDay)
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
}
