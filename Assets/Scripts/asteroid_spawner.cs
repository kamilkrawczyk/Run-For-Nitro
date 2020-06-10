using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public int timeBetweenSpawns;
    public float speed;
    [Space]
    public GameObject direction;

    private Vector3 dir;
    
    List<GameObject> _asteroids = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2, timeBetweenSpawns);
        dir = direction.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject g in _asteroids)
        {
            g.transform.position += dir * speed * Time.deltaTime;
            g.transform.Rotate(0, 0, 2);
        }
    }
    void Spawn()
    {
        GameObject asteroid = Instantiate(itemToSpawn, transform.position, itemToSpawn.transform.rotation);
        _asteroids.Add(asteroid);
        StartCoroutine(Destroy(asteroid));
    }
    IEnumerator Destroy(GameObject g)
    {
        yield return new WaitForSeconds(10);
        Destroy(g);
        yield return null;
    }
}
