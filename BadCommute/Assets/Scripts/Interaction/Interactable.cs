using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsPickUp = false;
    public bool isFigure = false;
    public UnityEvent Interact;
    public UnityEvent InteractSuccess;
    public UnityEvent InteractFail;
    public GameObject prompt_manager;
    public Ticket ticket;

    public string InteractText = "Interact [Left Click]";

    // Start is called before the first frame update
    void Start()
    {
        prompt_manager = UnityEngine.GameObject.FindWithTag("PromptManager");
        if(this.tag == "figure"){
            isFigure = true;
        }
    }

    public void promptInteraction(){
        if(isFigure){
            prompt_manager.GetComponent<Tick_tracker>().prompt_user("Give ticket to passenger [Left Click]");
        } else if (ticket != null) {
            prompt_manager.GetComponent<Tick_tracker>().prompt_user(ticket.ticket_name);
        }
        else
        {
            prompt_manager.GetComponent<Tick_tracker>().prompt_user(InteractText);
        }
    }

    public void DoInteract(PlayerInteract player)
    {
        Interact.Invoke();
        if (isFigure)
        {
            Debug.Log("------------------------------------------------");
            if (prompt_manager.GetComponent<Tick_tracker>().external_figure_interact() == true)
            {
                InteractSuccess.Invoke();
                GameObject.Destroy(gameObject);
            }
            else
            {
                InteractFail.Invoke();
            }
            prompt_manager.GetComponent<Tick_tracker>().prompt_user("");
        }
        else
        {
            prompt_manager.GetComponent<Tick_tracker>().external_ticket_update(ticket);
            GameObject.Destroy(gameObject);
            prompt_manager.GetComponent<Tick_tracker>().prompt_user("");
        }
    }
}
