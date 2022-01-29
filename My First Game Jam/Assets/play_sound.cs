using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_sound : MonoBehaviour
{
    [Header("sound of rolling")]
  
    [SerializeField]
    AK.Wwise.Event sound_event; //our sound from wwise

    //    sound_event.Post(gameObject); //play wwise sound on this game object
    //    sound_event.Stop(gameObject); //stop sound

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) | (Input.GetKeyDown(KeyCode.D))))
        { 
            sound_event.Post(gameObject); //play wwise sound on this game object
        }
        else if ((Input.GetKeyUp(KeyCode.A) | (Input.GetKeyUp(KeyCode.D))))
        {
            sound_event.Stop(gameObject);  //stop sound
        }
        


    } 
}
