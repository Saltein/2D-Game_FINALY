using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React : MonoBehaviour
{
    public float react_timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        react_timer += Time.deltaTime;
        if (react_timer >= 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
