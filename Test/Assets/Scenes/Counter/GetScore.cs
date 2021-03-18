using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public Text win;
    public static int cost = 0;
    [SerializeField]
    public Text score;
    public Button back;
    public Button pause;
    public static int winCount = 25;

    void Start()
    {
        cost = 0;
        score = GetComponent<Text>();
        win.enabled = false;
        back.gameObject.SetActive(false);
        back.enabled = false;
    }

    void Update()
    {
        if (cost < winCount)
        {
            score.text = "Score " + cost;
        }
        else
        {
            score.enabled = false;
            pause.enabled = false;
            pause.gameObject.SetActive(false);
            win.enabled = true;
            back.gameObject.SetActive(true);
            back.enabled = true;
        }
        if (cost < 0)
        {
            score.enabled = false;
            pause.enabled = false;
            pause.gameObject.SetActive(false);
        }
    }

}
