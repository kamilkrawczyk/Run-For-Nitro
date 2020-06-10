using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class los_enemy_controller : MonoBehaviour
{
    //VARIABLES//
    [Header("References")]
    public GameObject player;
    public GameObject groundChecker1;
    public GameObject groundChecker2;
    public LayerMask groundLayer;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsTouchingGround())
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        }
    }
    private bool IsTouchingGround()
    {
        Vector3 direction = Vector3.down;
        float distance = 1.0f;

        RaycastHit2D hit1 = Physics2D.Raycast(groundChecker1.transform.position, direction, distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(groundChecker2.transform.position, direction, distance, groundLayer);
        if ((hit1.collider != null) || (hit2.collider != null))
        {
            return true;
        }

        return false;
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
