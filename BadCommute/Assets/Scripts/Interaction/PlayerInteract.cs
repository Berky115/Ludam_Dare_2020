using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera PlayerCam;
    public float CastRadius = 0.1f;
    public float CastDistance = 1;

    public int TicketCount = 0;

    public bool LookingAtInteractable = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookingAtInteractable = false;

        Ray ray = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //int layerMask = 1 << 5;
        //layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, CastDistance))
        //if(Physics.Raycast(ray, out hit, CastDistance, layerMask))
        //if(Physics.SphereCast(ray, CastRadius, out hit, CastDistance))
        {
            Debug.DrawRay(PlayerCam.transform.position, PlayerCam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);


            Interactable iteractObject = hit.collider.GetComponent<Interactable>();
            if (iteractObject != null)
            {
                //cast found an interactable object, do anything related to that here.
                InteractHover();

                //Interact button was pressed (using "Fire1" for now, should be left mose click.)
                if (Input.GetButton("Fire1"))
                {
                    Interact(iteractObject);
                }
            }
        }

    }

    //Things that happen when hovering over Interactable Objects
    private void InteractHover()
    {
        LookingAtInteractable = true;
    }

    private void Interact(Interactable interact)
    {
        //Some kind of pause?

        interact.DoInteract(this);
    }

    public bool AddInventory()
    {
        if(TicketCount > 0)
        {
            return false;
        }
        else
        {
            TicketCount++;
            return true;
        }
    }
}
