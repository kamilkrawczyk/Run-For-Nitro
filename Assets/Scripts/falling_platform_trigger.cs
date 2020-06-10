using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_platform_trigger : MonoBehaviour
{
    public GameObject platform;
    private falling_platform platformScript;
    

   


    // Start is called before the first frame update
    void Start()
    {
        platformScript = platform.GetComponent<falling_platform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platformScript.shake = true;
            Destroy(gameObject);
        }
    }

   
}
