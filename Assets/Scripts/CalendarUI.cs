using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarUI : MonoBehaviour
{
    public InputField startDateField;  // Поле ввода начальной даты (Legacy InputField)
    public InputField endDateField;    // Поле ввода конечной даты (Legacy InputField)
    public GameObject calendarPanel;   // Панель календаря
    public TextMeshProUGUI monthYearText; // Текст текущего месяца и года (TextMeshPro)
    public Transform daysContainer;    // Контейнер для дней
    public GameObject dayPrefab;       // Префаб для дня
    public Color defaultDayColor = Color.black;       // Цвет по умолчанию
    public Color selectedDayColor = Color.white;      // Цвет выбранных дат
    public Color outOfRangeColor = Color.gray;        // Цвет недоступных дат

    public DateTime minDate = new DateTime(2000, 1, 1); // Минимальная доступная дата
    public DateTime maxDate = new DateTime(2100, 12, 31); // Максимальная доступная дата

    private DateTime selectedStartDate = DateTime.MinValue;
    private DateTime selectedEndDate = DateTime.MinValue;
    private DateTime currentDate;

    private InputField activeField; // Поле, для которого выбираем дату

    void Start()
    {
        calendarPanel.SetActive(false);
        currentDate = DateTime.Now;
        UpdateCalendar(currentDate);
    }

    public void OpenCalendar(InputField field)
    {
        activeField = field;
        calendarPanel.SetActive(true);
    }

    public void CloseCalendar()
    {
        calendarPanel.SetActive(false);
    }

    public void UpdateCalendar(DateTime date)
    {
        currentDate = date;
        monthYearText.text = currentDate.ToString("MMMM yyyy");

        foreach (Transform child in daysContainer)
        {
            Destroy(child.gameObject);
        }

        DateTime firstDay = new DateTime(currentDate.Year, currentDate.Month, 1);
        int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
        int startDayOfWeek = (int)firstDay.DayOfWeek;

        for (int i = 0; i < startDayOfWeek; i++)
        {
            Instantiate(dayPrefab, daysContainer).GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime currentDay = new DateTime(currentDate.Year, currentDate.Month, day);

            GameObject dayButton = Instantiate(dayPrefab, daysContainer);
            TextMeshProUGUI dayText = dayButton.GetComponentInChildren<TextMeshProUGUI>();
            Button button = dayButton.GetComponent<Button>();

            dayText.text = day.ToString();

            // Проверка на диапазон дат
            if (currentDay < minDate || currentDay > maxDate)
            {
                dayText.color = outOfRangeColor;
                button.interactable = false;
            }
            else
            {
                button.onClick.AddListener(() => OnDaySelected(currentDay));
                ColorBlock colorBlock = button.colors;
                // Подсветка выбранных дат
                if (selectedStartDate != DateTime.MinValue && currentDay == selectedStartDate)
                {
                    dayText.color = Color.white;
                    colorBlock.normalColor = Color.black;
                    button.colors = colorBlock;
                }
                else if (selectedEndDate != DateTime.MinValue && currentDay == selectedEndDate)
                {
                    dayText.color = Color.white;
                    colorBlock.normalColor = Color.black;
                    button.colors = colorBlock;
                }
                else if (selectedStartDate != DateTime.MinValue && selectedEndDate != DateTime.MinValue &&
                         currentDay > selectedStartDate && currentDay < selectedEndDate)
                {
                    dayText.color = Color.white * 0.8f; // Полупрозрачный зеленый для диапазона
                    colorBlock.normalColor = Color.black * 0.8f;
                    button.colors = colorBlock;
                }
                else
                {
                    dayText.color = Color.black;
                    button.colors = colorBlock;
                }
            }
        }
    }

    public void OnDaySelected(DateTime date)
    {
        if (activeField == startDateField)
        {
            selectedStartDate = date;
            startDateField.text = date.ToString("yyyy-MM-dd");

            // Если конечная дата меньше начальной, сбрасываем конечную дату
            if (selectedEndDate != DateTime.MinValue && selectedEndDate < selectedStartDate)
            {
                endDateField.text = "";
                selectedEndDate = DateTime.MinValue;
            }
        }
        else if (activeField == endDateField)
        {
            selectedEndDate = date;
            endDateField.text = date.ToString("yyyy-MM-dd");
        }

        UpdateCalendar(currentDate); // Обновить календарь для подсветки
    }

    public void NextMonth()
    {
        UpdateCalendar(currentDate.AddMonths(1));
    }

    public void PreviousMonth()
    {
        UpdateCalendar(currentDate.AddMonths(-1));
    }

    public void ButtonClick()
    {
        CloseCalendar();
    }
}
