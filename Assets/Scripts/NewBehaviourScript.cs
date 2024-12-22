using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class NewBehaviourScript : MonoBehaviour
{

    public Button submitButton;
    public TextMeshProUGUI TextDay;
    public TextMeshProUGUI TextInfo;

    // Start is called before the first frame update
    void Start()
    {
        TextDay.text = "Александровский сад";
        submitButton.onClick.AddListener(() => OnDayButtonClicked());
        TextInfo.text = "Александровский сад — парк в Тверском районе Москвы, расположен вдоль западной Кремлёвской стены, тянется от площади Революции до Кремлёвской набережной. Был основан в 1812 году. Парк площадью 10 гектаров состоит из трёх частей: Верхнего, Среднего и Нижнего садов. В нём находятся такие исторические объекты, как Кутафья башня Кремля, Итальянский грот, обелиск к 300-летию Дома Романовых и другие. Особое место занимают памятники, посвящённые Отечественной войне 1812 года и Великой Отечественной войне.";
    }

    private void OnDayButtonClicked()
    {
        SceneManager.LoadScene("DayScene");
    }
}