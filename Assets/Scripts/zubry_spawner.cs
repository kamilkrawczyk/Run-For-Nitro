using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zubry_spawner : MonoBehaviour
{
    public GameObject o1, o2, o3;
    public GameObject prefabToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        SpawnZubr(o1);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void SpawnZubr(GameObject g)
    {
        GameObject zubr = Instantiate(prefabToSpawn, g.transform.position, g.transform.rotation);
        zubr.GetComponentInChildren<zubr_collection>().czyJestKsiezycowy = true;
        Debug.Log(zubr.GetComponentInChildren<zubr_collection>().czyJestKsiezycowy);
    }
}
