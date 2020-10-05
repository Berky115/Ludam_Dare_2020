using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tick_tracker : MonoBehaviour
{
    public int beat_time;
    public GameObject lightSources;
    public int tick_value;
    public Text tick_display;
    public Text beat_prompt;
    public Text interact_prompt;
    public Text current_ticket_prompt;
    public int current_beat;
    public Ticket current_ticket;
    public string[] story_beats = {
            "Get off the train and go home...",
            "Find a ticket.",
            "gETT___OfF_train",
            "Why can't you get off the train?",
            "rentrer chez soi",
            "Go home...",
            "Where are you going?",
            "Find a way off the train",
            "Hurry up...",
            "Go home"
        };
    void Start()
    {
        tick_value = 0;
        current_beat = 0;
        tick_display.text = "Tick value at :" + tick_value.ToString();
         InvokeRepeating("incrememnt_tick", 0.0f,beat_time);
    }

    public void external_tick_update(int value = 5){
        tick_value += value;
        tick_display.text = "Tick value at :" + tick_value.ToString();
        //reset tick value from exploration
        if(tick_value >= 9) {
            current_beat += 1;
            tick_value = 0;
        }
    }

    public void external_ticket_update(Ticket ticket){
        current_ticket_prompt.text = ticket.description;
        current_ticket = ticket;
    }

    public bool external_figure_interact(){
        if(current_ticket != null){
        if(current_ticket.name == "valid_ticket") {
            beat_prompt.text = "Have a seat.";
            lightSources.SetActive(false);
            current_ticket = null;
            //SceneManager.LoadScene (sceneName:"ending");
            return true;
        } else if(current_ticket.name == "Void_ticket") {
            beat_prompt.text = "This ticket is too old to use...";
            StartCoroutine(FadeImage(true));
            return false;
        } else {
            beat_prompt.text = "This ticket is no good";
            StartCoroutine(FadeImage(true));
            return false;
        } 
        } else {
            beat_prompt.text = "You have no tickets...";
            StartCoroutine(FadeImage(true));
            return false;
        }
    }

    public void prompt_user(string prompt){
        interact_prompt.text = prompt;
    }

    void incrememnt_tick()
    {
        if(current_beat < story_beats.Length-1) {
            beat_prompt.text = story_beats[current_beat];
            current_beat += 1;
            StartCoroutine(FadeImage(true));
        } else {
            tick_display.text = "Story is over";
            beat_prompt.text = "Sit down...";
            CancelInvoke("incrememnt_tick"); 
        }
    }

IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 2; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                beat_prompt.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                // set color with i as alpha
                beat_prompt.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
 