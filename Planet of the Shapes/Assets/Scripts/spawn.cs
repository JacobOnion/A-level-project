using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject room;
    private GameObject currentRoom;
    public bool spawned;
    private Transform loc;
    private RoomOrganiser RoomOrganiser;
    private LayoutManager LayoutManager;
    public int ranNum;
    public int doors;
    private GameObject newSpawn;
    private Timer Timer;
    private GameObject victory;

    // Start is called before the first frame update
    void Start()
    {
        loc = gameObject.GetComponent<Transform>();
        Timer = gameObject.GetComponent<Timer>();
        victory = GameObject.Find("green background");
        RoomOrganiser = GameObject.Find("Room Manager").GetComponent<RoomOrganiser>();
        LayoutManager = GameObject.Find("Room Manager").GetComponent<LayoutManager>();

        Invoke("RoomSpawner", 0.2f); //calls the function after 0.2 seconds to give time to destroy the spawnpoint before it runs if necessary.
        
    }
    void RoomSpawner()
    {
        if ((spawned == false) && RoomOrganiser.roomsNum < RoomOrganiser.maxRooms) //Checks that a room hasn't been spawned yet, and the room limit hasn't been reached.
        {
            //controls the probability of generating a room with 1, 2 or 3 rooms.
            doors = Random.Range(1, 15);
            if (doors < 4)
            {
                ranNum = Random.Range(0, RoomOrganiser.oneDoor);
            }
            else if ((doors > 3) && (doors < 13))
            {
                ranNum = Random.Range(RoomOrganiser.oneDoor + 1, RoomOrganiser.twoDoor);
            }
            else
            {
                ranNum = Random.Range(RoomOrganiser.twoDoor + 1, RoomOrganiser.threeDoor);
            }

            // checks the position of the spawnpoint, and so selects a room with a door in the opposite direction to spawn.
            if (loc.localPosition.y == 1)
            {
                room = RoomOrganiser.downRooms[ranNum];
            }
            else if (loc.localPosition.x > 1.5f)
            {
                room = RoomOrganiser.leftRooms[ranNum];
            }
            else if (loc.localPosition.y == -1)
            {
                room = RoomOrganiser.upRooms[ranNum];
            }
            else if (loc.localPosition.x < -1.5f)
            {
                room = RoomOrganiser.rightRooms[ranNum];
            }
            currentRoom = Instantiate(room, transform.position, Quaternion.identity);
            RoomOrganiser.roomsNum += 1;
            if (RoomOrganiser.roomsNum == RoomOrganiser.maxRooms) //runs true if this is the final room generated
            {
                Debug.Log("done", currentRoom);
                Instantiate(victory, transform.position, Quaternion.identity);
            }
            spawned = true;
            //LayoutSpawner();
        }
    }

    private void LayoutSpawner()
    {
        GameObject newLayout = Instantiate(LayoutManager.layouts[Random.Range(0, LayoutManager.layouts.Length)], transform.position, Quaternion.identity); //spawns a random layout from the array
        GameObject currentEnemySpawner = newLayout.transform.Find("Enemy Spawner").gameObject;
        currentEnemySpawner.GetComponent<EnemySpawner>().doorSpawn = currentRoom.transform.Find("Enemy Spawn Area").gameObject.GetComponent<DoorSpawn>();//used to find the room the layout is in.
        //RoomOrganiser.enemySpawnerList.Add(currentEnemySpawner);
    }

    // if two spawnpoints collide,
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spawn") && gameObject.CompareTag("spawn")) //we only want the function to run if the two gameobjects are both spawnpoints
        {
            newSpawn = other.gameObject;
            Invoke("blockCheck", 0.1f); // called after 0.1 seconds to allow other scripts to run before the rest of the code is excecuted
            
        }
    }

    void blockCheck()
    {
        if (newSpawn != null) // if this runs false, the other spawnpoint has already been destroyed, so we avoid running the rest of the code to prevent null reference errors
        {
            if ((newSpawn.GetComponent<spawn>().spawned == false) && (spawned == false)) //this will only run true if the two spawnpoints were created on top of each other at the same time
            {
                //Instantiate(RoomOrganiser.wall, transform.position, Quaternion.identity);
                //spawned = true;
                spawned = true;
            }
            else
            {
                // destroys the newer spawnpoint to prevent rooms overalapping
                if (Timer.timeElapsed < newSpawn.GetComponent<Timer>().timeElapsed)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
