using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DayPrefabManager : MonoBehaviour
{
    public GameObject dayPrefab; // Префаб, который будет создан для каждого дня
    public Transform container;  // Контейнер, в котором будут располагаться префабы
    public Sprite[] dayImages;

    List<GameObject> days = new List<GameObject>();

    void Start()
    {
        // Получаем сохраненные даты из PlayerPrefs
        string startDateString = PlayerPrefs.GetString("StartDate");
        string endDateString = PlayerPrefs.GetString("EndDate");
        dayImages = Resources.LoadAll<Sprite>("Image/City/" + PlayerPrefs.GetString("City"));

        // Конвертируем строки в DateTime
        DateTime startDate = DateTime.Parse(startDateString);
        DateTime endDate = DateTime.Parse(endDateString);

        // Расчет количества дней между двумя датами
        TimeSpan difference = endDate - startDate;
        int totalDays = difference.Days + 1; // Включаем день начала

        // Генерация префабов
        for (int i = 0; i < totalDays; i++)
        {
            CreateDayPrefab(startDate.AddDays(i), i + 1);  // Добавляем день и порядковый номер
        }
    }

    // Метод для создания префаба дня
    private void CreateDayPrefab(DateTime dayDate, int dayNumber)
    {
        // Создаем экземпляр префаба
        GameObject dayObject = Instantiate(dayPrefab, container);

        // Получаем компоненты внутри префаба
        TextMeshProUGUI dayText = dayObject.GetComponentInChildren<TextMeshProUGUI>();  // Для надписи
        Button dayButton = dayObject.GetComponentInChildren<Button>();  // Для кнопки
        Image image = dayObject.GetComponentInChildren<Image>();

        // Устанавливаем текст с номером дня
        dayText.text = "День " + dayNumber;

        if (dayImages.Length > 0)
        {
            image.sprite = dayImages[dayNumber % dayImages.Length]; // В цикле используем изображения
        }

        // Привязываем обработчик к кнопке
        dayButton.onClick.AddListener(() => OnDayButtonClicked(dayNumber));
        days.Add(dayObject);

        // Можно добавить дополнительные настройки, например, дату в текст
        // dayText.text += " - " + dayDate.ToString("dd/MM/yyyy");
    }

    // Метод для обработки нажатия на кнопку дня
    private void OnDayButtonClicked(int dayNumber)
    {
        PlayerPrefs.SetString("Day", dayNumber.ToString());
        SceneManager.LoadScene("DayScene");
    }
}
