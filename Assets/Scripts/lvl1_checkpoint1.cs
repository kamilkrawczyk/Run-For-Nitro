using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_checkpoint1 : MonoBehaviour
{
   public bool trigger1active;

    private void Start()
    {
        trigger1active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger1active = true;
    }
}
