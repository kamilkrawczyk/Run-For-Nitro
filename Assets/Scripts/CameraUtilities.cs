using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtilities : MonoBehaviour
{
    private Vector2 targetPoint;
    private bool startMoving, startCheckingForEnd;
    private float _speed;
    public bool movementDone;

    private void Start()
    {
        movementDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(startMoving)
        {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPoint.x,targetPoint.y,transform.position.z), step);          
        }

        if(startCheckingForEnd)
        {
            if (transform.position == new Vector3(targetPoint.x, targetPoint.y, transform.position.z)) //if camera is it the target
            {
                movementDone = true;
                targetPoint = Vector2.zero;
                startMoving = false;
                startCheckingForEnd = true;
           }
        }
        

    }
    public void MoveCameraToPoint(Vector2 point, float speed)
    {
        targetPoint = point;
        _speed = speed;
        startMoving = true;
        startCheckingForEnd = true;
    }
}
