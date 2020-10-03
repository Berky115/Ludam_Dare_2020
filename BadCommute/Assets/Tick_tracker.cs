﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tick_tracker : MonoBehaviour
{
    public int tick_value;
    public Text tick_display;
    public Text beat_prompt;
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

    void incrememnt_tick()
    {
        if(current_beat < story_beats.Length-1) {
            current_beat += 1;
            beat_prompt.text = story_beats[current_beat];
        } else {
            tick_display.text = "Story is over";
            beat_prompt.text = "Sit down...";
            CancelInvoke("incrememnt_tick"); 
        }
    }

}
 