using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreResources : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private void Update()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
}
