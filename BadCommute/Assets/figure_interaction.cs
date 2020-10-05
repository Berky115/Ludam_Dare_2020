using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class figure_interaction : MonoBehaviour
{
    public UnityEvent Interact;
    public GameObject prompt_manager;

    // Start is called before the first frame update
    void Start()
    {
        prompt_manager = UnityEngine.GameObject.FindWithTag("PromptManager");
    }

    public void promptInteraction(){
        Debug.Log("figure promt found");
        prompt_manager.GetComponent<Tick_tracker>().prompt_user("Talk to passenger");
    }

    public void DoInteract(PlayerInteract player)
    {
        Interact.Invoke();
            Debug.Log("Attempting interaction.");
            if (prompt_manager.GetComponent<Tick_tracker>().external_figure_interact() == true){
                GameObject.Destroy(gameObject);
                prompt_manager.GetComponent<Tick_tracker>().prompt_user("???");
            } 
    }
}
