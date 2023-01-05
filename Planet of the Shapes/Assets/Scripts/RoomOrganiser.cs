using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoomOrganiser : MonoBehaviour
{
    public GameObject[] upRooms;
    public GameObject[] rightRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    private List<GameObject[]> roomLists = new List<GameObject[]>();
    public GameObject wall;
    public int oneDoor;
    public int twoDoor;
    public int threeDoor;
    public int roomsNum;
    public static int maxRooms = 4;
    public bool genFinished;
    private TextMeshProUGUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        scoreUI.text = ("Score: " + EnemySpawner.score);

        roomLists.AddRange(new List<GameObject[]>
        {
            upRooms, downRooms, rightRooms, leftRooms
        });

        foreach (GameObject[] list in roomLists) //Insertion sort used on each array
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if (list[j-1].name.Length > list[j].name.Length)
                    {
                        GameObject temp = list[j -1];
                        list[j -1] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        //calculates where in each list the last room with one, two and three doors is.
        //Only has to be done once, since each array has the same rooms, just rotated appropriately.
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
    }
}
