using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    int howManyLayers;

    public GameObject[] onionLayer;

    Vector3 extraLayer = new Vector3(1, 1, 0);

    PlayerMovement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<PlayerMovement>();

        howManyLayers = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        }
    }

    public void Detach()
    {
        if(howManyLayers > 0)
        {
            howManyLayers -= 1;
            moveScript.movementSpeed += 25f;
            transform.localScale -= extraLayer;
        }

        Instantiate(onionLayer[howManyLayers - 1]);
    }
}
