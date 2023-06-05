using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeScript : MonoBehaviour
{
    GameObject aim;
    [SerializeField] GameObject fire;
    Vector3 target;
    float timer = 0;
    float launchTime = 2f;

    private void Awake()
    {
        aim = GameObject.FindWithTag("aim");
    }

    private void Start()
    {
        target = new Vector3(aim.transform.position.x, aim.transform.position.y, transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, 0.3f);

        if (timer >= launchTime)
        {
            Instantiate(fire, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
    }
}
