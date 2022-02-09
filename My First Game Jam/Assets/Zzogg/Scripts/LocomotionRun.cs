using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionRun : MonoBehaviour
{
  
  
    void PlayerRunSound()
    {
        AkSoundEngine.PostEvent("play_player_loco_footsteps_material", gameObject);

    }

    void PlayerJumpSound()
    {
        AkSoundEngine.PostEvent("play_player_vocs_edude_sighs", gameObject);

    }


}
