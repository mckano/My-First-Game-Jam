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
    }

    private void Update()
    {
        angularVelocity = rb.angularVelocity;
        AkSoundEngine.SetRTPCValue("RTPC_LayerSpeed", rb.angularVelocity, gameObject); // wwise
    }
}
