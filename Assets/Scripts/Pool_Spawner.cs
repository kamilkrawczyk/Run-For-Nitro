using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Spawner : MonoBehaviour
{
    public GameObject poolToSpawn, poolUI;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPool();
    }
    
    void SpawnPool()
    {
        Instantiate(poolToSpawn, transform.position, transform.rotation);
    }
    
}
