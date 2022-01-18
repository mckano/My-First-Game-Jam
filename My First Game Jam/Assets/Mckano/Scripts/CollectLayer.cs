using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLayer : MonoBehaviour
{

    bool touchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        touchingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerController lcScript = collision.GetComponent<LayerController>();

        if(lcScript != null)
        {
            lcScript.touchingLayer = true;
            touchingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        LayerController lcScript = collision.GetComponent<LayerController>();

        if (lcScript != null)
        {
            lcScript.touchingLayer = false;
            touchingPlayer = false;
        }
    }
}
