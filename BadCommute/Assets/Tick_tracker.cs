using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tick_tracker : MonoBehaviour
{
    public int tick_value;
    public Text tick_display;
    public Text beat_prompt;
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
        tick_display.text = "Tick value at :" + tick_value.ToString();
        beat_prompt.text = story_beats[tick_value];
         InvokeRepeating("incrememnt_tick", 2.0f, 2.0f);
    }

    void incrememnt_tick()
    {
        if(tick_value < story_beats.Length-1) {
            tick_value += 1;
            tick_display.text = "Tick value at :" + tick_value.ToString();
            beat_prompt.text = story_beats[tick_value];
            Debug.Log("Tick value is sound " + story_beats.Length);
            Debug.Log(tick_value);
        } else {
            Debug.Log("Involk cancelled");
            CancelInvoke("incrememnt_tick"); 
        }
    }

}
 