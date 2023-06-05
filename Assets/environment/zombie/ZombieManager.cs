using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public int zombieHP;
    float timer;
    float damageTime = 0.5f;
    float defaultSpeed;

    float force = 0.001f;
    [SerializeField] GameObject damageZone;

    [SerializeField] GameObject scrap;
    [SerializeField] GameObject rag;
    [SerializeField] GameObject wood;
    [SerializeField] GameObject brick;
    [SerializeField] GameObject chemical;

    int scrapAm, chemicAm, ragAm, woodAm, brickAm;

    [SerializeField] GameObject deadZombie;

    private void Start()
    {
        zombieHP = 100;

        scrapAm = Random.Range(1, 3);
        chemicAm = Random.Range(0, 3);
        ragAm = Random.Range(1, 2);
        woodAm = Random.Range(0, 2);
        brickAm = Random.Range(0, 2);
    }

    private void Update()
    {
        if (zombieHP <= 0)
        {
            Instantiate(deadZombie, transform.position, transform.rotation);
            if (scrapAm != 0)
            {
                for (int i = 0; i < scrapAm; i++)
                {
                    Rigidbody2D rb = Instantiate(scrap, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)), ForceMode2D.Impulse);
                }
            }
            if (chemicAm != 0)
            {
                for (int i = 0; i < chemicAm; i++)
                {
                    Rigidbody2D rb = Instantiate(chemical, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)), ForceMode2D.Impulse);
                }
            }
            if (ragAm != 0)
            {
                for (int i = 0; i < ragAm; i++)
                {
                    Rigidbody2D rb = Instantiate(rag, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)), ForceMode2D.Impulse);
                }
            }
            if (woodAm != 0)
            {
                for (int i = 0; i < woodAm; i++)
                {
                    Rigidbody2D rb = Instantiate(wood, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)), ForceMode2D.Impulse);
                }
            }
            if (brickAm != 0)
            {
                for (int i = 0; i < brickAm; i++)
                {
                    Rigidbody2D rb = Instantiate(brick, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)), ForceMode2D.Impulse);
                }
            }

            Destroy(damageZone);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bullet_ak-47":
                zombieHP -= 40;
                break;

            case "bullet_turret":
                zombieHP -= 70;
                break;
        }  
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (timer >= damageTime && collision.gameObject.tag == "barbedWire")
        {
            zombieHP -= 1;
            timer = 0;
        }
    }
}
