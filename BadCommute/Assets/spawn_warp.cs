using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_warp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] respawns;
    public bool head;
    void Start()
    {
       
        Debug.Log(respawns.Length);
    }


 void OnTriggerExit(Collider other) {
     Debug.Log("Stepping in");
     if (other.tag == "Player")
        {
            Debug.Log("Player found");
            if(head){
                respawns = GameObject.FindGameObjectsWithTag("tail_spawn");
            } else {
                 respawns = GameObject.FindGameObjectsWithTag("valid_spawn");
            }
            int rand = Random.Range(0, respawns.Length);
            respawns[rand].GetComponent<Collider>().enabled = false;
            StartCoroutine(ActivationRoutine(respawns[rand]));
            other.transform.position = respawns[rand].transform.position;
            
        } else {
            Debug.Log("Not a player");
        }

 }

  private IEnumerator ActivationRoutine(GameObject spawn)
     {        
         Debug.Log("STARTING ROUTINE");
         yield return new WaitForSeconds(1);
         spawn.GetComponent<Collider>().enabled = true;
         Debug.Log("Ending Routine");
     }
}
