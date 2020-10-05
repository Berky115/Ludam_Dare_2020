using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    public GameObject[] PhantomList;
    private Tick_tracker PromptManager;

    private int lastTick;


    public GameObject[] RealTicketList;

    // Start is called before the first frame update
    void Start()
    {
        
        PromptManager = GameObject.FindGameObjectWithTag("PromptManager").GetComponent<Tick_tracker>();
        UpdateSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTick != PromptManager.current_beat)
        {
            UpdateSpawn();
        }
    }

    public void UpdateSpawn()
    {
        //Get data from Prompt manager
        int currentStoryBeat = PromptManager.current_beat;
        int maxBeats = PromptManager.story_beats.Length-1;


        //Update Phantom Spawning
        int spawnGroupSize = 0;
        int totalToSpawn = 0;
        if(currentStoryBeat > 1)
        {
            //Activate the appropriate Phantoms
            spawnGroupSize = PhantomList.Length / (maxBeats);
            totalToSpawn = (spawnGroupSize * currentStoryBeat) - 1;
        }

        //Show all phantoms if we hit the end
        if (currentStoryBeat == maxBeats)
        {
            totalToSpawn = PhantomList.Length;
        }

        //Show/Hide Phantoms
        for(int i = 0; i < PhantomList.Length; i++)
        {
            if (i < totalToSpawn)
            {
                 PhantomList[i].SetActive(true);
            }
            else
            {
                PhantomList[i].SetActive(false);
            }
        }

        //Update the Real Tickets
        foreach(GameObject realTicket in RealTicketList)
        {
            realTicket.SetActive(currentStoryBeat == maxBeats);
        }

        //Track the last Story Beat to update
        lastTick = currentStoryBeat;

    }
}
