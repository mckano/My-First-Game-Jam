using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{

    public GameObject[] onionLayer;
    public bool touchingLayer;

    int howManyLayers;
    Vector3 extraLayer = new Vector3(1, 1, 0);
    PlayerMovement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        touchingLayer = false;
        moveScript = GetComponent<PlayerMovement>();
        howManyLayers = 4;
    }

    // Update is called once per frame
    void Update()
    {
        print(touchingLayer);
        if (Input.GetKeyDown(KeyCode.E) && touchingLayer)
        {
            ReAttach();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Detach();
        }

        switch (howManyLayers)
        {
            case 4:
                print("I have 4 layers");
                break;
            case 3:
                print("I have 3 layers");
                break;
            case 2:
                print("I have 2 layers");
                break;
            case 1:
                print("I have 1 layer");
                break;
            case 0:
                print("I have no layers");
                break;
        }
    }

    public void ReAttach()
    {
        if(howManyLayers < 4)
        {
            howManyLayers += 1;
            moveScript.movementSpeed -= 25f;
            transform.localScale += extraLayer;
            touchingLayer = false;
        }
    }

    public void Detach()
    {
        if(howManyLayers > 0)
        {
            Instantiate(onionLayer[howManyLayers - 1], transform.position, transform.rotation);

            howManyLayers -= 1;
            moveScript.movementSpeed += 25f;
            transform.localScale -= extraLayer;
        }

    }
}
