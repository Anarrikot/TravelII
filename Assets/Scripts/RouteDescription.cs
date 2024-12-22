using UnityEngine;
using TMPro;

public class RouteDescription : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;  // UI элемент для отображения текста
    public string[] routeText = new string[]
    {
        "Прогулка по красной площади\nВыходим из места “Театральная”, дальше по маршруту.",
        "\n\nПосетить:\n- Храм Василия Блаженного 300-2000 руб.\n- Исторический музей 300-2000 руб.",
        "\n\nРестораны:\n- Barbosco (4,6) ср. чек от 3000 руб.\n- Магадан (4,7) ср. чек от 1500 руб."
    };

    void Start()
    {
        DisplayRouteInfo();
    }

    public void DisplayRouteInfo()
    {
        // Обновляем текст в UI
        descriptionText.text = string.Join("\n", routeText);
    }
}
