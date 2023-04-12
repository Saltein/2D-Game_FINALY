using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBloodReact : MonoBehaviour
{
    public float Blood_react_timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Blood_react_timer += Time.deltaTime;
        if (Blood_react_timer >= 30f)
        {
            Destroy(gameObject);
        }
    }
}
