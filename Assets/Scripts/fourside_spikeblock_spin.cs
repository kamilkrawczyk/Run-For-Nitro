using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourside_spikeblock_spin : MonoBehaviour
{
    public bool rotate;
    [Range(.5f, 10)]
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate)
        {
            gameObject.transform.Rotate(0, 0, rotateSpeed);
        }
       
    }
}
