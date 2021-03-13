using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public static int cost = 0;
    Text score;
    void Start()
    {

        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cost < 30)
        {
            score.text = "Score " + cost;
        }
        else
        {
            score.text = "You win!";
        }
    }

}
