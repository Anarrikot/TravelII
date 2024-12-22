using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Autocomplete : MonoBehaviour
{
    public InputField inputField;       // ���� �����
    public GameObject suggestionPanel; // ������ � �����������
    public GameObject suggestionPrefab; // ������ ���������
    public Button buttonAgree;
    public List<string> data = new List<string> { "������", "�����", "������", "��������", "������", "�����", "��������" };          // ������ (������ � ������)

    private List<GameObject> suggestions = new List<GameObject>();

    void Start()
    {
        inputField.onValueChanged.AddListener(OnInputChanged);
        suggestionPanel.SetActive(false); // ������ ������ ��������� �������
    }

    void OnInputChanged(string input)
    {
        ClearSuggestions();

        if (string.IsNullOrEmpty(input))
        {
            suggestionPanel.SetActive(false);
            return;
        }

        // ��������� ������
        List<string> matches = data.FindAll(item => item.ToLower().StartsWith(input.ToLower()));

        // ���������� ����������
        foreach (string match in matches)
        {
            GameObject suggestion = Instantiate(suggestionPrefab, suggestionPanel.transform);
            suggestion.GetComponentInChildren<TMP_Text>().text = match; // ���������� TMP_Text

            // ��������� ���������� �������
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