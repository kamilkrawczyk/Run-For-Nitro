using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knur_animation_death : MonoBehaviour {

    public GameObject groupToDestroy;
    public GameObject knurToFollow;

    AudioSource aSource;
    public float volume = 1;
    public AudioClip death;

    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();
        Invoke("Die", 0.8f);
        aSource.PlayOneShot(death, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = knurToFollow.transform.position;
	}

    void Die()
    {
        Destroy(groupToDestroy);
    }
}
