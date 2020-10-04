using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsPickUp = false;
    public UnityEvent Interact;
    public GameObject prompt_manager;
    public Ticket ticket;

    // Start is called before the first frame update
    void Start()
    {
        prompt_manager = UnityEngine.GameObject.FindWithTag("PromptManager");
    }

    public void promptInteraction(){
        prompt_manager.GetComponent<Tick_tracker>().prompt_user(ticket.ticket_name);
    }

    public void DoInteract(PlayerInteract player)
    {
        Interact.Invoke();
        if (IsPickUp)
        {
            GameObject.Destroy(gameObject);
            prompt_manager.GetComponent<Tick_tracker>().prompt_user("");
        }
    }
}
