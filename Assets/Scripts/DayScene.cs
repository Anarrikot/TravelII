using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class DayScene : MonoBehaviour
{

    public Button submitButton;
    public TextMeshProUGUI TextDay;
    public TextMeshProUGUI textDayInfo;
    public string[] routeText = new string[]
    {
        "Прогулка по красной площади\nВыходим из места “Театральная”, дальше по маршруту.",
        "\n\nПосетить:\n- Храм Василия Блаженного 300-2000 руб.\n- Исторический музей 300-2000 руб.",
        "\n\nРестораны:\n- Barbosco (4,6★) ср. чек от 3000 руб.\n- Магадан (4,7★) ср. чек от 1500 руб."
    };

    // Start is called before the first frame update
    void Start()
    {
        string startDateString = PlayerPrefs.GetString("Day");
        TextDay.text = "День " + startDateString;
        textDayInfo.text = string.Join("\n", routeText);
        submitButton.onClick.AddListener(() => OnDayButtonClicked());
    }

    private void OnDayButtonClicked()
    {
        SceneManager.LoadScene("ListDays");
    }
}
