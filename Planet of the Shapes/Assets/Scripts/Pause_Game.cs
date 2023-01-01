using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Pause_Game : MonoBehaviour
{
    public Canvas menu;
    private float gameSpeed;

    void Start()
    {
        gameSpeed = GameObject.Find("Game Manager").GetComponent<Easy_Mode>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        menu.enabled=false;
        Time.timeScale = gameSpeed;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
