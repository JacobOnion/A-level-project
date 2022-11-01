using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomOrganiser : MonoBehaviour
{
    public GameObject[] upRooms;
    public GameObject[] rightRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public List<GameObject> enemySpawnerList = new List<GameObject>();
    public List<GameObject> spawnAreaList = new List<GameObject>();
    public GameObject wall;
    public int oneDoor;
    public int twoDoor;
    public int threeDoor;
    public int roomsNum;
    public int maxRooms;
    public bool genFinished;

    // Start is called before the first frame update
    void Start()
    {
        //calculates where in each list the last room with one, two and three doors is, since they are ordered. Only has to be done once, since each array has the same rooms, just rotated appropriately.
        //sorting algorithm?
        for (int i = 0; i < upRooms.Length; i++)
        {
            if (upRooms[i].name.Length == 1)
            {
                oneDoor = i;
            }
            else if (upRooms[i].name.Length == 2)
            {
                twoDoor = i;
            }
            else if (upRooms[i].name.Length == 3)
            {
                threeDoor = i;
            }
        }
        Invoke("cleaner", 3f); //Waits three seconds before running to allow the level to finish generating.
    }


    void cleaner()
    {
        Debug.Log(roomsNum);
        if (roomsNum < maxRooms) //remakes the level if certain parameters aren't met
        {
            SceneManager.LoadScene("Gameplay");
        }

        GameObject[] spawnList = GameObject.FindGameObjectsWithTag("spawn");

        for (int i = 0; i < spawnList.Length; i++)  //Destroys all spawnpoints in the scene, and closes off any open doors with walls.
        {
            if(spawnList[i].GetComponent<spawn>().spawned == false)
            {
            Instantiate(wall, spawnList[i].transform.position, Quaternion.identity);
            }
            Destroy(spawnList[i]);
        }

        genFinished = true;


        /*foreach (GameObject spawner in enemySpawnerList)
        {
            spawner.SetActive(true); //re-activates all spawners after the spawnpoints have been deleted
        }*/
        spawnList = null;
        enemySpawnerList = null;
    }
}
