using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

    public GameObject player;
    private float playerPosXLastFrame;
    private float playerPosYLastFrame;

    public enum WorkState {MoveAlong, MoveAgainst}
    public WorkState _workState;

    public float moveAmountXAxis = 0.01f;
    public float moveAmountYAxis = 0.01f;

    public bool moveInXAxis;
    public bool moveInYAxis;

    

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if(_workState == WorkState.MoveAgainst)
        {
            if (moveInXAxis)
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    if (Mathf.Abs(player.transform.position.x - playerPosXLastFrame) > 0.01f)
                    {
                        if (player.GetComponent<Player>().velocity.x > 0)
                        {
                            gameObject.transform.position += new Vector3(-moveAmountXAxis, 0, 0);
                        }
                        else if (player.GetComponent<Player>().velocity.x < 0)
                        {
                            gameObject.transform.position += new Vector3(moveAmountXAxis, 0, 0);
                        }
                    }

                }

            }
            playerPosXLastFrame = player.transform.position.x;
            if (moveInYAxis)
            {
                if (player.GetComponent<Player>().velocity.y != 0)
                {
                    if (player.GetComponent<Player>().velocity.y > 0)
                    {
                        gameObject.transform.position += new Vector3(0, -moveAmountXAxis, 0);
                    }
                    else if (player.GetComponent<Player>().velocity.y < 0)
                    {
                        gameObject.transform.position += new Vector3(0, moveAmountXAxis, 0);
                    }
                }
            }
            playerPosYLastFrame = player.transform.position.y;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(_workState == WorkState.MoveAlong)
        {
            if (moveInXAxis)
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    if (Mathf.Abs(player.transform.position.x - playerPosXLastFrame) > 0.01f)
                    {
                        if (player.GetComponent<Player>().velocity.x > 0)
                        {
                            gameObject.transform.position += new Vector3(moveAmountXAxis, 0, 0);
                        }
                        else if (player.GetComponent<Player>().velocity.x < 0)
                        {
                            gameObject.transform.position += new Vector3(-moveAmountXAxis, 0, 0);
                        }
                    }

                }

            }
            playerPosXLastFrame = player.transform.position.x;
            if (moveInYAxis)
            {
                if (player.GetComponent<Player>().velocity.y != 0)
                {
                    if (player.GetComponent<Player>().velocity.y > 0)
                    {
                        gameObject.transform.position += new Vector3(0, moveAmountXAxis, 0);
                    }
                    else if (player.GetComponent<Player>().velocity.y < 0)
                    {
                        gameObject.transform.position += new Vector3(0, -moveAmountXAxis, 0);
                    }
                }
            }
            playerPosYLastFrame = player.transform.position.y;
        }
        
    }
}
