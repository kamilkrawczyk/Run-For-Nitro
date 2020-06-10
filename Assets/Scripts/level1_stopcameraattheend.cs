using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_stopcameraattheend : MonoBehaviour
{

    public GameObject camera;
    private CameraFollow cameraScript;
    public GameObject background, background2;
    private BackgroundMover bgScript;


    private void Start()
    {
        cameraScript = camera.GetComponent<CameraFollow>();
        bgScript = background.GetComponent<BackgroundMover>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraScript.enabled = false;
            bgScript.enabled = false;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraScript.enabled = true;
            bgScript.enabled = true;

        }

    }
}
