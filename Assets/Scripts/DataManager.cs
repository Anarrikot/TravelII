using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Для загрузки сцен

public class DataManager : MonoBehaviour
{
    public InputField inputField1;  // Поле ввода начала периода
    public InputField inputField2;  // Поле ввода конца периода
    public InputField inputField3;  // Поле ввода начала периода
    public InputField inputField4;  // Поле ввода конца периода
    public Button submitButton;     // Кнопка отправки

    void Start()
    {
        submitButton.onClick.AddListener(SaveDataAndLoadScene);
    }

    // Метод, который будет сохранять данные и переходить на новую сцену
    private void SaveDataAndLoadScene()
    {
        // Сохранение данных из InputField в PlayerPrefs
        PlayerPrefs.SetString("StartDate", inputField1.text);  // Дата начала
        PlayerPrefs.SetString("EndDate", inputField2.text);    // Дата конца
        PlayerPrefs.SetString("City", inputField3.text);  // Дата начала
        PlayerPrefs.SetString("Money", inputField4.text);    // Дата конца

        // Переход на следующую сцену (укажите имя вашей сцены)
        SceneManager.LoadScene("ListDays");
    }
}