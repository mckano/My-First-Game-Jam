using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_sound_jump : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event sound_event; //our sound from wwise



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            sound_event.Post(gameObject); //play wwise sound on this game object
                                  
    }



}
