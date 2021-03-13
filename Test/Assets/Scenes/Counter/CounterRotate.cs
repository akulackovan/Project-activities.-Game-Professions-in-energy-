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
    public int result = 0;

    void Start()
    {
        StartCoroutine(LoopFunction(button));

        button.onClick.AddListener(TaskOnClick);
    }

    public int getRes()
    {
        return result;
    }

    public IEnumerator LoopFunction(Button button)
    {
        while (GetScore.cost < 30)
        {
            int time = Random.Range(1, 5);
            Debug.Log(time);
            yield return new WaitForSecondsRealtime(time);
            button.image.color = hoverColor;
            click = true;
        }
    }
    void Update()
    {
        if (GetScore.cost == 30)
        {
            transform.Rotate(0, 0, 0.0f);
            button.interactable = false;
            button.image.color = basicColor;
        }
        else
        {
            transform.Rotate(0, 0, 0.2f);
        }
    }

    void TaskOnClick()
    {
        button.image.color = basicColor;
        if (click == true)
        {
            GetScore.cost += 1;
        }
        click = false;
    }

    public void stop()
    {
        transform.Rotate(0, 0, 0.0f);
    }

    IEnumerator waiter(int time, Button button)
    {
        yield return new WaitForSecondsRealtime(time);
        button.image.color = hoverColor;
    }
}
