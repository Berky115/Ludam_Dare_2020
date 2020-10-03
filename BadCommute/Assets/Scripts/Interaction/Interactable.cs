using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsPickUp = false;
    public UnityEvent Interact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoInteract(PlayerInteract player)
    {
        Interact.Invoke();
        if (IsPickUp)
        {
            if (player.AddInventory())
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
