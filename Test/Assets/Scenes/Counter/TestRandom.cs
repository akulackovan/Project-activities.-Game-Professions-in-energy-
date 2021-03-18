using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    void Start()
    {

        time = Random.Range(-5, 5);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, time);
    }
}
