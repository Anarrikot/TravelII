using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DayPrefabManager : MonoBehaviour
{
    public GameObject dayPrefab; // ������, ������� ����� ������ ��� ������� ���
    public Transform container;  // ���������, � ������� ����� ������������� �������
    public Sprite[] dayImages;

    List<GameObject> days = new List<GameObject>();

    void Start()
    {
        // �������� ����������� ���� �� PlayerPrefs
        string startDateString = PlayerPrefs.GetString("StartDate");
        string endDateString = PlayerPrefs.GetString("EndDate");
        dayImages = Resources.LoadAll<Sprite>("Image/City/" + PlayerPrefs.GetString("City"));

        // ������������ ������ � DateTime
        DateTime startDate = DateTime.Parse(startDateString);
        DateTime endDate = DateTime.Parse(endDateString);

        // ������ ���������� ���� ����� ����� ������
        TimeSpan difference = endDate - startDate;
        int totalDays = difference.Days + 1; // �������� ���� ������

        // ��������� ��������
        for (int i = 0; i < totalDays; i++)
        {
            CreateDayPrefab(startDate.AddDays(i), i + 1);  // ��������� ���� � ���������� �����
        }
    }

    // ����� ��� �������� ������� ���
    private void CreateDayPrefab(DateTime dayDate, int dayNumber)
    {
        // ������� ��������� �������
        GameObject dayObject = Instantiate(dayPrefab, container);

        // �������� ���������� ������ �������
        TextMeshProUGUI dayText = dayObject.GetComponentInChildren<TextMeshProUGUI>();  // ��� �������
        Button dayButton = dayObject.GetComponentInChildren<Button>();  // ��� ������
        Image image = dayObject.GetComponentInChildren<Image>();

        // ������������� ����� � ������� ���
        dayText.text = "���� " + dayNumber;

        if (dayImages.Length > 0)
        {
            image.sprite = dayImages[dayNumber % dayImages.Length]; // � ����� ���������� �����������
        }

        // ����������� ���������� � ������
        dayButton.onClick.AddListener(() => OnDayButtonClicked(dayNumber));
        days.Add(dayObject);

        // ����� �������� �������������� ���������, ��������, ���� � �����
        // dayText.text += " - " + dayDate.ToString("dd/MM/yyyy");
    }

    // ����� ��� ��������� ������� �� ������ ���
    private void OnDayButtonClicked(int dayNumber)
    {
        PlayerPrefs.SetString("Day", dayNumber.ToString());
        SceneManager.LoadScene("DayScene");
    }
}
