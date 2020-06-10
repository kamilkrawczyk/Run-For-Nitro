using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_item_spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public float timeBeetwenSpawns;

    public enum Orientation { Left, Right, Down, Up }
    public Orientation orientation;
    [Range(0, 15)]
    public float rotationSpeed;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem",1, timeBeetwenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem()
    {
        Instantiate(itemToSpawn, transform.position, transform.rotation);
        if(itemToSpawn.name == "twarozek32x32")
        {
            if(orientation == Orientation.Down)
            {
                itemToSpawn.GetComponent<twarozek>().orientation = twarozek.Orientation.Down;
                itemToSpawn.GetComponent<twarozek>().rotationSpeed = rotationSpeed;
            }
            else if (orientation == Orientation.Left)
            {
                itemToSpawn.GetComponent<twarozek>().orientation = twarozek.Orientation.Left;
                itemToSpawn.GetComponent<twarozek>().rotationSpeed = rotationSpeed;
            }
            else if (orientation == Orientation.Up)
            {
                itemToSpawn.GetComponent<twarozek>().orientation = twarozek.Orientation.Up;
                itemToSpawn.GetComponent<twarozek>().rotationSpeed = rotationSpeed;
            }
            else if (orientation == Orientation.Right)
            {
                itemToSpawn.GetComponent<twarozek>().orientation = twarozek.Orientation.Right;
                itemToSpawn.GetComponent<twarozek>().rotationSpeed = -rotationSpeed;
            }
            itemToSpawn.GetComponent<twarozek>().movementSpeed = moveSpeed;
        }
    }
}
