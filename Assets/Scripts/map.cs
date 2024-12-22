using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public AbstractMap map_my;

    void Start()
    {
        // Устанавливаем координаты для центра карты (Москва)
        Vector2d cityCoordinates = new Vector2d(55.7558, 37.6176);
        map_my.SetCenterLatitudeLongitude(cityCoordinates);
    }
}
