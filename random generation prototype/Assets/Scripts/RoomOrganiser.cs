using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOrganiser : MonoBehaviour
{
    public GameObject[] upRooms;
    public GameObject[] rightRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public GameObject[] spawnList;
    public GameObject wall;
    public int oneDoor;
    public int twoDoor;
    public int threeDoor;
    public int roomsNum;

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
        Invoke("cleaner", 5f); //Waits five seconds before running to allow the level to finish generating.
    }

    //Destroys all spawnpoints in the scene, and closes off any open doors with walls.
    void cleaner()
    {
        spawnList = GameObject.FindGameObjectsWithTag("spawn");
        for (int i = 0; i < spawnList.Length; i++)
        {
            if(spawnList[i].GetComponent<spawn>().spawned == false)
            {
            Instantiate(wall, spawnList[i].transform.position, Quaternion.identity);
                Debug.Log(spawnList[i].transform.position);
            }
            Destroy(spawnList[i]);
        }
    }
}
