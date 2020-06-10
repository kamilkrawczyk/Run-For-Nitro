using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_score_upwards : MonoBehaviour {

    
    public GameObject group;

	// Use this for initialization
	void Start () {
        Invoke("Die", 3);
	}
   

    // Update is called once per frame
    void FixedUpdate () {
        
            gameObject.transform.Translate(new Vector3(0, 0.4f, 0) * Time.deltaTime);
        
    }
    void Die()
    {
        Destroy(group);
    }
}
