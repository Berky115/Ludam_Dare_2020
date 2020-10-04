using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera PlayerCam;
    public float CastRadius = 0.1f;
    public float CastDistance = 3;
    public GameObject ticket_view;

    public int TicketCount = 0;

    public GameObject prompt_manager;


    void Start()
    {
        prompt_manager = UnityEngine.GameObject.FindWithTag("PromptManager");
        ticket_view = UnityEngine.GameObject.Find("current_ticket");
        ticket_view.SetActive(!ticket_view.activeSelf);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
           ticket_view.SetActive(!ticket_view.activeSelf);
        }

        Ray ray = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, CastDistance))
        {
            Debug.DrawRay(PlayerCam.transform.position, PlayerCam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            Interactable iteractObject = hit.collider.GetComponent<Interactable>();
            if (iteractObject != null)
            {
                //cast found an interactable object, do anything related to that here.
                InteractHover(iteractObject);

                //Interact button was pressed (using "Fire1" for now, should be left mose click.)
                if (Input.GetButton("Fire1"))
                {
                    Interact(iteractObject);
                }
            } else {
                 prompt_manager.GetComponent<Tick_tracker>().prompt_user("");
            }
        }
    }

    //Things that happen when hovering over Interactable Objects
    private void InteractHover(Interactable interact)
    {
        interact.promptInteraction();
    }


    private void Interact(Interactable interact)
    {
        interact.DoInteract(this);
    }
}
