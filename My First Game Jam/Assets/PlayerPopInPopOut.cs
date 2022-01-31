using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPopInPopOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("play_player_loco_pop_in", gameObject);
    }

    // AkSoundEngine.PostEvent("play_player_loco_pop_out", gameObject);
}
