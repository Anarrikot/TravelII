using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MapMarker : MonoBehaviour
{
    public GameObject markerPrefab;  // ������ ��� �������
    private AbstractMap map_my;         // ����� Mapbox

    void Start()
    {
        map_my = FindObjectOfType<AbstractMap>();  // ������� ������ ����� � �����
        AddMarker(new Vector2d(55.752075, 37.613611));  // ���������� ������� �������, ������
    }

    // ����� ��� ���������� ������� �� �����
    public void AddMarker(Vector2d coordinates)
    {
        var marker = Instantiate(markerPrefab);
        var latLon = map_my.GeoToWorldPosition(coordinates);
        marker.transform.position = latLon;  // ���������� ������ � ������ ����������
        marker.AddComponent<MarkerClickHandler>().mapMarker = this;
    }
}

public class MarkerClickHandler : MonoBehaviour
{
    public MapMarker mapMarker; // ������ �� MapMarker ��� ��������� ��������

    // ����� ��� ��������� ������ �� ������
    void OnMouseDown()
    {
        // ������� �� ����� ����� (��������, Scene2)
        SceneManager.LoadScene("New Scene"); // ������� �������� �����, �� ������� ����� �������
    }
}
