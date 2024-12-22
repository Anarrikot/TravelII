using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ListDaysBack : MonoBehaviour
{
    public Button submitButton;

    // Start is called before the first frame update
    void Start()
    {
        submitButton.onClick.AddListener(() => OnDayButtonClicked());
    }

    private void OnDayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
