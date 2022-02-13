using UnityEngine;

public class OnionLayer : MonoBehaviour
{
    public int layerSize;
    public float angularVelocity;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AkSoundEngine.SetRTPCValue("RTPC_LayerSize", layerSize, gameObject); // wwise
        //Debug.Log(layerSize);
        AkSoundEngine.PostEvent("play_player_layer_rolling_onion", gameObject);
    }

    private void FixedUpdate()
    {
        angularVelocity = rb.angularVelocity;
        AkSoundEngine.SetRTPCValue("RTPC_LayerSpeed", Mathf.Abs(angularVelocity), gameObject);  // wwise
        //Debug.Log(Mathf.Abs(angularVelocity));
    }


    private void OnDestroy()
    {
        AkSoundEngine.PostEvent("play_player_layer_rolling_onion_stop", gameObject);
    }
}
