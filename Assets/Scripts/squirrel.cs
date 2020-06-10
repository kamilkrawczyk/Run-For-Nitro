using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrel : MonoBehaviour
{
    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 4.5f * Time.deltaTime;
        if(Vector3.Distance(transform.position,end.transform.position)<1)
        {
            Destroy(gameObject);
        }
    }
}
