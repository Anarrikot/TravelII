using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Autocomplete : MonoBehaviour
{
    public InputField inputField;       // Поле ввода
    public GameObject suggestionPanel; // Панель с подсказками
    public GameObject suggestionPrefab; // Префаб подсказки
    public Button buttonAgree;
    public List<string> data = new List<string> { "Москва", "Минск", "Мадрид", "Мельбурн", "Мехико", "Милан", "Малайзия" };          // Данные (города и страны)

    private List<GameObject> suggestions = new List<GameObject>();

    void Start()
    {
        inputField.onValueChanged.AddListener(OnInputChanged);
        suggestionPanel.SetActive(false); // Скрыть панель подсказок вначале
    }

    void OnInputChanged(string input)
    {
        ClearSuggestions();

        if (string.IsNullOrEmpty(input))
        {
            suggestionPanel.SetActive(false);
            return;
        }

        // Фильтруем данные
        List<string> matches = data.FindAll(item => item.ToLower().StartsWith(input.ToLower()));

        // Показываем совпадения
        foreach (string match in matches)
        {
            GameObject suggestion = Instantiate(suggestionPrefab, suggestionPanel.transform);
            suggestion.GetComponentInChildren<TMP_Text>().text = match; // Используем TMP_Text

            // Добавляем обработчик нажатия
            suggestion.GetComponentInChildren<UnityEngine.UI.Button>().onClick.AddListener(() => OnSuggestionClicked(match));

            suggestions.Add(suggestion);
        }

        suggestionPanel.SetActive(matches.Count > 0);
    }

    void OnSuggestionClicked(string suggestion)
    {
        inputField.text = suggestion;
        ClearSuggestions();
        suggestionPanel.SetActive(false);
    }

    void ClearSuggestions()
    {
        foreach (GameObject suggestion in suggestions)
        {
            Destroy(suggestion);
        }
        suggestions.Clear();
    }
}