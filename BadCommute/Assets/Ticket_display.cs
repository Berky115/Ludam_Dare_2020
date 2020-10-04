using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket_display : MonoBehaviour
{
    // Start is called before the first frame update
    public Ticket ticket;

    void Start()
    {
        Debug.Log(ticket.ticket_name);
    }

}
