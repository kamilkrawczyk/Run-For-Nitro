using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiowoz : MonoBehaviour
{
    public GameObject endOfRoad;
    public int speed = 3;
 

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
        if(Vector3.Distance(gameObject.transform.position,endOfRoad.transform.position)<1)
        {
            Destroy(gameObject);
        }
    }
}
