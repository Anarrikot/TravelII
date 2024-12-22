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
        TextDay.text = "��������������� ���";
        submitButton.onClick.AddListener(() => OnDayButtonClicked());
        TextInfo.text = "��������������� ��� � ���� � �������� ������ ������, ���������� ����� �������� ���������� �����, ������� �� ������� ��������� �� ���������� ����������. ��� ������� � 1812 ����. ���� �������� 10 �������� ������� �� ��� ������: ��������, �������� � ������� �����. � �� ��������� ����� ������������ �������, ��� ������� ����� ������, ����������� ����, ������� � 300-����� ���� ��������� � ������. ������ ����� �������� ���������, ����������� ������������� ����� 1812 ���� � ������� ������������� �����.";
    }

    private void OnDayButtonClicked()
    {
        SceneManager.LoadScene("DayScene");
    }
}