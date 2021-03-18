using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CounterRotate : MonoBehaviour

{
    [SerializeField]
    public Button button;
    public static Color basicColor = Color.white;
    public static Color hoverColor = Color.red;
    public bool click = false;
    private float timer = 0;
    float time;
    private float timerMax = 0;
    private float timerLoose = 5;
    private float timeLast = 0;
    private float startTime = 3.0f;
    private float endTime = 6.0f;
    public Text lose;
    public Button back;

    void Start()
    {
        lose.enabled = false;
        back.gameObject.SetActive(false);
        back.enabled = false;
        button.image.color = basicColor;
        time = 0;
        click = false;
        timerMax = 0;
        timeLast = 0;
        time = Random.Range(startTime, endTime);
        timer = time + Time.time;
    }

    void Update()
    {
        if (GetScore.cost < 0)
        {
            button.image.color = hoverColor;
            transform.Rotate(0, 0, 0.0f);
            lose.enabled = true;
            back.gameObject.SetActive(true);
            back.enabled = true;
            button.onClick.RemoveAllListeners();
        }
        else if (GetScore.winCount < GetScore.cost)
        {
            button.image.color = basicColor;
            transform.Rotate(0, 0, 0.0f);
        }
        else
        {
            transform.Rotate(0, 0, 0.3f);
            if (!Waited()) return;
            if (timeLast <= Time.time)
            {
                GetScore.cost = -10;
            }
        }
    }

    void TaskOnClick()
    {
        if (click == true)
        {
            GetScore.cost += 1;
        }
        click = false;
        time = Random.Range(startTime, endTime);
        timer = time + Time.time;
        button.image.color = basicColor;
    }

    private bool Waited()
    {
        timerMax = Time.time;
        if (timer >= timerMax)
        {
            timeLast = Time.time + timerLoose;
            return true;
        }
        button.image.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 0.3f));
        click = true;
        if (timeLast <= timerMax)
        {
            GetScore.cost = -10;
        }
        button.onClick.AddListener(TaskOnClick);
        return false;
    }
}
