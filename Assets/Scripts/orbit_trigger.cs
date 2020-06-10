using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit_trigger : MonoBehaviour
{
    public dialogue_global_controller dialogueController;
    public GameObject dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogueController.AtTheDialogueStart();
            dialogueController.Orbit();
            Cursor.visible = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
