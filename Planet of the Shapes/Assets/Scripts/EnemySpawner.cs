using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] waves;
    public DoorSpawn doorSpawn;
    public GameObject currentWave;
    private int wavesCompleted;
    private bool disabled;

    private void Awake()
    {
        if (disabled == false)
        {
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        bool sorted = false;
        GameObject temp;
        while (sorted == false)
        {
            sorted = true;
            for (int i = 0; i < waves.Length-1; i++)
            {
               if (int.Parse(waves[i].name) > int.Parse(waves[i+1].name))
                {
                    temp = waves[i];
                    waves[i] = waves[i+1];
                    waves[i+1] = temp;
                    sorted = false;
                }
            }
        }
    }

    void OnDisable()
    {
        disabled = true;
    }

    void Update()
    {
        if (doorSpawn != null)
        {
            if (doorSpawn.RoomEntered)
            {
                if (wavesCompleted == waves.Length)
                {
                    if (currentWave.transform.childCount == 0)
                    {
                        doorSpawn.RoomComplete();
                        Destroy(gameObject);
                    }
                }
                else if (currentWave.transform.childCount == 0)
                {
                    currentWave = Instantiate(waves[wavesCompleted], transform.position, Quaternion.identity);
                    wavesCompleted += 1;
                }
            }
        }
    }

}
