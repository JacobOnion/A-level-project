using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
