using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // ��� �������� ����

public class DataManager : MonoBehaviour
{
    public InputField inputField1;  // ���� ����� ������ �������
    public InputField inputField2;  // ���� ����� ����� �������
    public InputField inputField3;  // ���� ����� ������ �������
    public InputField inputField4;  // ���� ����� ����� �������
    public Button submitButton;     // ������ ��������

    void Start()
    {
        submitButton.onClick.AddListener(SaveDataAndLoadScene);
    }

    // �����, ������� ����� ��������� ������ � ���������� �� ����� �����
    private void SaveDataAndLoadScene()
    {
        // ���������� ������ �� InputField � PlayerPrefs
        PlayerPrefs.SetString("StartDate", inputField1.text);  // ���� ������
        PlayerPrefs.SetString("EndDate", inputField2.text);    // ���� �����
        PlayerPrefs.SetString("City", inputField3.text);  // ���� ������
        PlayerPrefs.SetString("Money", inputField4.text);    // ���� �����

        // ������� �� ��������� ����� (������� ��� ����� �����)
        SceneManager.LoadScene("ListDays");
    }
}