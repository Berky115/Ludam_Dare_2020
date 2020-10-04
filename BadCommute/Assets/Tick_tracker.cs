using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tick_tracker : MonoBehaviour
{
    public int tick_value;
    public Text tick_display;
    public Text beat_prompt;
    public Text interact_prompt;
    public Text current_ticket_prompt;
    private int current_beat;
    public string[] story_beats = {
            "Get off the train and go home...",
            "Get off the train",
            "Why can't you get off the train?",
            "gETT___OfF_train",
            "rentrer chez soi",
            "it's a train bruh...",
            "Go home...",
            "Sit down"
        };
    void Start()
    {
        tick_value = 0;
        current_beat = 0;
        tick_display.text = "Tick value at :" + tick_value.ToString();
        beat_prompt.text = story_beats[tick_value];
        //automatically move to next tick over time.
         InvokeRepeating("incrememnt_tick", 2.0f, 2.0f);
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
    }

    public void prompt_user(string prompt){
        interact_prompt.text = prompt;
    }

    void incrememnt_tick()
    {
        if(current_beat < story_beats.Length-1) {
            current_beat += 1;
            beat_prompt.text = story_beats[current_beat];
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
 