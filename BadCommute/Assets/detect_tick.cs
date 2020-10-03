using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detect_tick : MonoBehaviour
{
    public GameObject tick_manager;

    void Start() {
         GameObject.FindObjectWithTag("Player");
    }

    void OnTriggerExit(Collider  collision)
    {
        Debug.Log("TRIGGER!!!!");
        if (collision.tag == "Player")
        {
            tick_manager.tick_value += 10;
        }
    }
}
