using UnityEngine;
using UnityEngine.UI;  // ��� ������ � UI ������������
using TMPro;  // ��� ������ � TextMeshPro, ���� �� ����������� ���

public class ButtonAgree : MonoBehaviour
{
    public InputField inputField1;
    public InputField inputField2;
    public InputField inputField3;
    public InputField inputField4;

    public Button submitButton;
    public TextMeshProUGUI buttonText;

    void Start()
    {
        // ���������� ������ ������ ���������� � ������ ���� ��� ���������� ������
        submitButton.interactable = false;
        submitButton.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 84);

        // ��������� ����������� ������� ��� ���� InputField
        inputField1.onValueChanged.AddListener(OnInputChanged);
        inputField2.onValueChanged.AddListener(OnInputChanged);
        inputField3.onValueChanged.AddListener(OnInputChanged);
        inputField4.onValueChanged.AddListener(OnInputChanged);
    }

    // ���� ����� ����� ����������, ����� ������������ ������ �����
    private void OnInputChanged(string input)
    {
        // ���������, ��� �� ���� ���������
        if (AreFieldsFilled())
        {
            // ���� ��� ���� ���������, ������ ������ �������� � ������ ����
            submitButton.interactable = true;
            submitButton.GetComponent<Image>().color = Color.black;
            buttonText.color = Color.white;
        }
        else
        {
            // ���� ���� �� ���� ���� �� ���������, ������ ��������� � ���� �� ���������
            submitButton.interactable = false;
            submitButton.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 84);
            buttonText.color = Color.HSVToRGB(0, 0, 53);
        }
    }

    // ����� ��� ��������, ��� ��� ���� ���������
    private bool AreFieldsFilled()
    {
        return !string.IsNullOrEmpty(inputField1.text) &&
               !string.IsNullOrEmpty(inputField2.text) &&
               !string.IsNullOrEmpty(inputField3.text) &&
               !string.IsNullOrEmpty(inputField4.text);
    }
}
