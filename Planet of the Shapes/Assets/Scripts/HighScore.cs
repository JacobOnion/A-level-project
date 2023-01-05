using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = ("HIGH-SCORE: " + PlayerPrefs.GetInt("HighScore"));
        }
    }
}
