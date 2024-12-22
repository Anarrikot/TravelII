using UnityEngine;
using UnityEngine.UI;  // Для работы с UI компонентами
using TMPro;  // Для работы с TextMeshPro, если вы используете его

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
        // Изначально делаем кнопку неактивной и задаем цвет для неактивной кнопки
        submitButton.interactable = false;
        submitButton.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 84);

        // Добавляем обработчики событий для всех InputField
        inputField1.onValueChanged.AddListener(OnInputChanged);
        inputField2.onValueChanged.AddListener(OnInputChanged);
        inputField3.onValueChanged.AddListener(OnInputChanged);
        inputField4.onValueChanged.AddListener(OnInputChanged);
    }

    // Этот метод будет вызываться, когда пользователь вводит текст
    private void OnInputChanged(string input)
    {
        // Проверяем, все ли поля заполнены
        if (AreFieldsFilled())
        {
            // Если все поля заполнены, делаем кнопку активной и меняем цвет
            submitButton.interactable = true;
            submitButton.GetComponent<Image>().color = Color.black;
            buttonText.color = Color.white;
        }
        else
        {
            // Если хотя бы одно поле не заполнено, кнопка неактивна и цвет по умолчанию
            submitButton.interactable = false;
            submitButton.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 84);
            buttonText.color = Color.HSVToRGB(0, 0, 53);
        }
    }

    // Метод для проверки, что все поля заполнены
    private bool AreFieldsFilled()
    {
        return !string.IsNullOrEmpty(inputField1.text) &&
               !string.IsNullOrEmpty(inputField2.text) &&
               !string.IsNullOrEmpty(inputField3.text) &&
               !string.IsNullOrEmpty(inputField4.text);
    }
}
