using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon_items_controller : MonoBehaviour
{
    public enum Actions { none, rotateAroundItself}
    public Actions actions;
    public float rotateSpeed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(actions == Actions.rotateAroundItself)
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
    }
}
