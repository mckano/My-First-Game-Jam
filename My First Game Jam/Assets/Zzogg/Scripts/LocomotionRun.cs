using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionRun : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Collider2D myCollider;

    void PlayerRunSound()
    {
        RaycastHit2D hitObject = MaterialChecker();
        if (hitObject.collider.tag != null)
        {
            AkSoundEngine.SetSwitch("Material", hitObject.collider.tag, gameObject);
            AkSoundEngine.PostEvent("play_player_loco_footsteps_material", gameObject);
            Debug.Log(hitObject.collider.tag); //Debug.DrawRay(transform.position, Vector2.down, Color.green, 1);
        }

        else
        {
            Debug.Log("no floor tag!");
        }
    }

    void PlayerJumpSound()
    {
        AkSoundEngine.PostEvent("play_player_vocs_edude_sighs", gameObject);

    }

    void PlayerLandingSound() 
    {
        RaycastHit2D hitObject = MaterialChecker();
        if (hitObject.collider.tag != null)
        {
            AkSoundEngine.SetSwitch("Material", hitObject.collider.tag, gameObject);
            AkSoundEngine.PostEvent("play_player_loco_footsteps_material", gameObject);
            Debug.Log(hitObject.collider.tag); //Debug.DrawRay(transform.position, Vector2.down, Color.green, 1);
        }

        else
        {
            Debug.Log("no floor tag!");
        }

    }

    RaycastHit2D MaterialChecker()
    {
        Vector3 legsCenterPosition = new Vector3(myCollider.bounds.center.x, myCollider.bounds.min.y, myCollider.bounds.center.z);
        RaycastHit2D hitObject = Physics2D.Raycast(legsCenterPosition + Vector3.down * 0.1f, Vector2.down, 0.1f);
        return hitObject;

    }

}
