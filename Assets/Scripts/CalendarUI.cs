using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarUI : MonoBehaviour
{
    public InputField startDateField;  // ���� ����� ��������� ���� (Legacy InputField)
    public InputField endDateField;    // ���� ����� �������� ���� (Legacy InputField)
    public GameObject calendarPanel;   // ������ ���������
    public TextMeshProUGUI monthYearText; // ����� �������� ������ � ���� (TextMeshPro)
    public Transform daysContainer;    // ��������� ��� ����
    public GameObject dayPrefab;       // ������ ��� ���
    public Color defaultDayColor = Color.black;       // ���� �� ���������
    public Color selectedDayColor = Color.white;      // ���� ��������� ���
    public Color outOfRangeColor = Color.gray;        // ���� ����������� ���

    public DateTime minDate = new DateTime(2000, 1, 1); // ����������� ��������� ����
    public DateTime maxDate = new DateTime(2100, 12, 31); // ������������ ��������� ����

    private DateTime selectedStartDate = DateTime.MinValue;
    private DateTime selectedEndDate = DateTime.MinValue;
    private DateTime currentDate;

    private InputField activeField; // ����, ��� �������� �������� ����

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

            // �������� �� �������� ���
            if (currentDay < minDate || currentDay > maxDate)
            {
                dayText.color = outOfRangeColor;
                button.interactable = false;
            }
            else
            {
                button.onClick.AddListener(() => OnDaySelected(currentDay));
                ColorBlock colorBlock = button.colors;
                // ��������� ��������� ���
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
                    dayText.color = Color.white * 0.8f; // �������������� ������� ��� ���������
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

            // ���� �������� ���� ������ ���������, ���������� �������� ����
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

        UpdateCalendar(currentDate); // �������� ��������� ��� ���������
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
