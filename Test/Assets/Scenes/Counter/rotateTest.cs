using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        time = Random.Range(1, 5);
        transform.Rotate(0, 0, time);
    }
}
