using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jebak_jumpOverCamera : MonoBehaviour
{
    public GameObject jebak;
    private bool canJump;

    private void Start()
    {
        canJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canJump)
        {
            if (collision.CompareTag("cameraThrown"))
            {
                jebak.GetComponent<jejebak>().Jump();
                canJump = false;
                Invoke("JumpAgain", 8);
            }
        }
    }
    void JumpAgain()
    {
        canJump = true;
    }
}
