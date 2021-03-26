using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cost : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]

    public Text win;
    public bool winE;
    public Text loose;

    [SerializeField] public Image[] real;
    public static int cost = 0;
    [SerializeField]
    public Button back;
    public Button pause;
    public static int winCount = 5;
    public static Image []number = new Image[5];

    void Start()
    {
        winE = true;
        cost = 0;
        win.enabled = false;
        loose.enabled = false;
        back.gameObject.SetActive(false);
        back.enabled = false;
    }

    void Update()
    {
        if (cost == winCount)
        {
            for (int i = 0; i < 5; i++)
            {
                if (number[i] != real[i])
                {
                    pause.enabled = false;
                    pause.gameObject.SetActive(false);
                    loose.enabled = true;
                    back.gameObject.SetActive(true);
                    back.enabled = true;
                    winE = false;
                }
            }
            if (winE)
            {

                pause.enabled = false;
                pause.gameObject.SetActive(false);
                win.enabled = true;
                back.gameObject.SetActive(true);
                back.enabled = true;
            }
            else
            {
                pause.enabled = false;
                pause.gameObject.SetActive(false);
                loose.enabled = true;
                back.gameObject.SetActive(true);
                back.enabled = true;
                winE = false;

            }
        }
    }
}
