using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public Transform SpawnLocation;

    public void SpawnObjectAtTransform()
    {
        GameObject clone = GameObject.Instantiate(ObjectToSpawn, SpawnLocation.position, SpawnLocation.rotation);
    }
}
