using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_after_pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Die", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Die()
    {
        Destroy(gameObject);
    }
}
