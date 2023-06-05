using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeScript : MonoBehaviour
{
    [SerializeField] GameObject aim;
    Vector3 target;
    float timer = 0;


    private void Start()
    {
        target = aim.transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, 0.3f);


        timer += Time.deltaTime;
    }
}
