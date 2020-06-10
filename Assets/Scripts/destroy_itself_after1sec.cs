using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_itself_after1sec : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Die", 0.3f);
	}
	
	void Die()
    {
        Destroy(gameObject);
    }
}
