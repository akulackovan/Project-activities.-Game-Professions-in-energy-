using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Cards : MonoBehaviour
{
    [SerializeField]
    public Button[] questionB;
    public Button[] answerB;
    [SerializeField]
    public Text score;
    public Text win;
    public Text lose;
    public Button back;
    public Button undo;

    private bool questionClick = false;

    int counter = 0;
    int run = 0;

    private int indexQ = -1;
    private int indexA = -1;
    int[] indexQuestion = { 0,1,2,3,4};
    int[] indexAnswer = { 0, 1, 2, 3, 4 };
    private string[] question = { "Водопровод", "Ввод водопровода", "Видеостена", "Электромонтер", "Паводок" };
    private string[] answer = { "Система непрерывного водоснабжения потребителей", "Трубопровод, соединяющий городской водопровод с внутренним",
        "Оборудование в ЦПУ ГЭС", "Наименование профессии", "Ежегодный период самой напряженной работы" };
    public static Color basicColor = Color.white;
    public static Color hoverColor = Color.red;
    public static Color okColor = Color.green;

    private Dictionary<string, string> map = new Dictionary<string, string>();

    void Start()
    {
        back.gameObject.SetActive(false);
        undo.gameObject.SetActive(true);
        back.enabled = false;
        undo.enabled = true;
        win.enabled = false;
        lose.enabled = false;
        for (int i = 0; i < questionB.Length; i++)
        {
            questionB[i].interactable = true;
            answerB[i].interactable = true;
        }
       
        for (int i = indexQuestion.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = indexQuestion[j];
            indexQuestion[j] = indexQuestion[i];
            indexQuestion[i] = temp;
        }
        for (int i = indexAnswer.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = indexAnswer[j];
            indexAnswer[j] = indexAnswer[i];
            indexAnswer[i] = temp;
        }

        for (int i = 0; i < questionB.Length; i++)
        {
            questionB[indexQuestion[i]].GetComponentInChildren<Text>().text = question[i];
            answerB[indexAnswer[i]].GetComponentInChildren<Text>().text = answer[i];
            map.Add(questionB[indexQuestion[i]].GetComponentInChildren<Text>().text, answerB[indexAnswer[i]].GetComponentInChildren<Text>().text);
        }
        questionClick = false;
        score.text = "0/5";

    }

    void Update()
    {
        if (run == 5)
        {
            if (counter == 5)
            {
                win.enabled = true;
            }
            else
            {
                lose.enabled = true;
            }
            back.gameObject.SetActive(true);
            back.enabled = true;
            undo.gameObject.SetActive(false);
            undo.enabled = false;
        }

    }

    public void checkQuestion(int levelIndex)
    {
        if (!questionClick)
        {
            questionClick = true;
            indexQ = indexQuestion[levelIndex];
        }
    }

    public void check(int levelIndex)
    {
        if (questionClick)
        {
            if (map[questionB[indexQ].GetComponentInChildren<Text>().text] == answerB[indexAnswer[levelIndex]].GetComponentInChildren<Text>().text)
            {
                answerB[indexQ].image.color = okColor;
                questionB[levelIndex].image.color = okColor;
                questionB[levelIndex].interactable = false;
                answerB[indexQ].interactable = false;
                counter++;
            }
            else
            {
                answerB[levelIndex].image.color = hoverColor;
                questionB[indexQ].image.color = hoverColor;
                questionB[indexQ].interactable = false;
                answerB[levelIndex].interactable = false;
            }
            questionClick = false;
            run++;
        }
        score.text = counter + "/5";
    }


}
