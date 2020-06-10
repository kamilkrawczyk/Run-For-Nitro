using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_pics_in_menu : MonoBehaviour {

    public GameObject go;

  
    public void OnMouseEnter()
    {       
        go.SetActive(true);
    }
    private void OnMouseExit()
    {
        go.SetActive(false);
    }
}
