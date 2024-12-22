using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MapMarker : MonoBehaviour
{
    public GameObject markerPrefab;  // Префаб для маркера
    private AbstractMap map_my;         // Карта Mapbox

    void Start()
    {
        map_my = FindObjectOfType<AbstractMap>();  // Находим объект карты в сцене
        AddMarker(new Vector2d(55.752075, 37.613611));  // Координаты Красной площади, Москва
    }

    // Метод для добавления маркера на карту
    public void AddMarker(Vector2d coordinates)
    {
        var marker = Instantiate(markerPrefab);
        var latLon = map_my.GeoToWorldPosition(coordinates);
        marker.transform.position = latLon;  // Перемещаем маркер в нужные координаты
        marker.AddComponent<MarkerClickHandler>().mapMarker = this;
    }
}

public class MarkerClickHandler : MonoBehaviour
{
    public MapMarker mapMarker; // Ссылка на MapMarker для обработки перехода

    // Метод для обработки кликов на маркер
    void OnMouseDown()
    {
        // Переход на новую сцену (например, Scene2)
        SceneManager.LoadScene("New Scene"); // Укажите название сцены, на которую нужно перейти
    }
}
