using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detect_tick : MonoBehaviour
{
    public GameObject tick_manager;

    void Start() {
         tick_manager = UnityEngine.GameObject.FindWithTag("PromptManager");
    }

    void OnTriggerExit(Collider  collision)
    {
        if (collision.tag == "Player")
        {
            tick_manager.GetComponent<Tick_tracker>().external_tick_update(3);
        } else {
            Debug.Log("Something is a miss");
        }
    }
}
