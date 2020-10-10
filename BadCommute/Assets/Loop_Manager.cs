using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop_Manager : MonoBehaviour
{
    
    public GameObject[] cartPrefabs;   

    private Transform playerTransform;

        private List<GameObject> activeCarts = new List<GameObject>();

    private float spawnZ = 0.0f;
    private float cartLength = 32.0f;

    private int cartsOnScreen = 3;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for( int i = 0; i < cartsOnScreen; i++) {
            SpawnCart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ - cartsOnScreen * cartLength)) {
            SpawnCart();
            destroyCart();
        // } else if (playerTransform.position.z < (spawnZ - cartsOnScreen * cartLength) - (cartLength-1)){
        //     Debug.Log("OH NO He'S GOING BACKWARDS!!!!");
        //     SpawnBackCart();
        //     DestroyFrontCart();
        // }
        
    }

    private void SpawnCart(int prefafIndex = -1){
        GameObject go;
        go = Instantiate (cartPrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        activeCarts.Add(go);
        spawnZ += cartLength;
    }

    private void SpawnBackCart(int prefafIndex = -1){
        GameObject go;
        go = Instantiate (cartPrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.back * spawnZ;
        activeCarts.Add(go);
        spawnZ -= cartLength;
    }

    private void DestroyFrontCart(){
        GameObject furthest = activeCarts[activeCarts.Count-1];
        activeCarts.Remove(furthest);
        Destroy(furthest.gameObject);
    }

    private void destroyCart(){
        GameObject furthest = activeCarts[0];
        activeCarts.Remove(furthest);
        Destroy(furthest.gameObject);
    }
}
