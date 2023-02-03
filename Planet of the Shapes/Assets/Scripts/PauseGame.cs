using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Canvas menu;

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
        Time.timeScale = 1;
    }

    public void Quit()
    {
        EnemySpawner.score = 0;
        RoomOrganiser.maxRooms = 4;
        SceneManager.LoadScene("Main Menu");
    }
}
