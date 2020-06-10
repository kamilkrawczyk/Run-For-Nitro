using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SoundPlayer : MonoBehaviour
{
    public AudioClip clipToPlay;
    public float volume;

    [Header("References")]
    public GameObject gameCamera;

    private AudioSource a_source;
    // Start is called before the first frame update
    void Start()
    {
        a_source = gameCamera.GetComponent<AudioSource>();
        volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            a_source.PlayOneShot(clipToPlay, volume);
            Destroy(gameObject);
        }
    }
}
