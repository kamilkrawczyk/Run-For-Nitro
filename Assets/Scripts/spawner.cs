using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public int timeBeetwenSpawnings;
   
    public LayerMask spawnLayer;
    bool isSpawned;

    private GameObject spawnedItem;
    
    
    

    void Start()
    {
        isSpawned = false;           
    }
    void Update()
    {
       
        
       if(spawnedItem == null)
       {
            Debug.Log("no item");
            if (!isSpawned)
            {
                Invoke("Spawn", timeBeetwenSpawnings);
                isSpawned = true;
            }
       }
   
    }
    void Spawn()
    {
        GameObject item = Instantiate(itemToSpawn,transform.position,itemToSpawn.transform.rotation);    
        if(item.tag == "poolToCollect") //jesli spawnuje basen
        {
            gameObject.SetActive(false);//wylacz sie
        }
        spawnedItem = item;
        isSpawned = false;
       
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    }




}
