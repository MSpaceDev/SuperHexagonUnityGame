using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner instance;

    public GameObject hexagon;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void StartSpawning(float spawnSpeed)
    {
        InvokeRepeating("SpawnHexagon", 0.0f, spawnSpeed);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    void SpawnHexagon()
    {
        GameObject hexagonIns = Instantiate(hexagon, Vector3.zero, Quaternion.identity, transform);

        hexagonIns.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }
}
