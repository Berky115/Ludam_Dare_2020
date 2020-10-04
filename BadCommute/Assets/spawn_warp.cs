using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_warp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] respawns;
    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("valid_spawn");
        Debug.Log(respawns.Length);
    }


 void OnTriggerExit(Collider other) {
     Debug.Log("Stepping in");
     if (other.tag == "Player")
        {
            Debug.Log("Player found");
            
            int rand = Random.Range(0, respawns.Length);
            respawns[rand].SetActive(false);
            other.transform.position = respawns[rand].transform.position;
            
            ActivationRoutine(respawns[rand]);
        } else {
            Debug.Log("Not a player");
        }

 }

  private IEnumerator ActivationRoutine(GameObject spawn)
     {        
         yield return new WaitForSeconds(3);
         spawn.SetActive(true);
     }
}
