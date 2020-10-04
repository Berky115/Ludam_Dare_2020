using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ticket", menuName = "Ticket")]
public class Ticket : ScriptableObject
{
    public string ticket_name;
    public string description;
    public Sprite icon;

}
