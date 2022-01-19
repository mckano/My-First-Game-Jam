using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionLayerManager : MonoBehaviour
{
    public int numberOfLayers;
    private OnionLayerStorage layerStorage;
    private static float epsilonForAttachingDistance = 0.02f;

    private void Start()
    {
        layerStorage = GameObject.Find("OnionLayerStorage").GetComponent<OnionLayerStorage>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AttemptDetach();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttemptAttach();
        }
    }

    private void AttemptDetach()
    {
        if (numberOfLayers > 0 && isSpaceOnTop())
        {
            Instantiate(layerStorage.onionLayers[numberOfLayers], transform.position, transform.rotation);
            // TODO: calculate proper distance for outer layer to spawn exactly on top of the outer layer
            Instantiate(layerStorage.onionPlayers[numberOfLayers - 1], transform.position + Vector3.up * 2, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void AttemptAttach()
    {
        GameObject layerToAttach = FindNearestEligibleLayer();
        if (layerToAttach != null && IsLayerToAttachCloseEnough(layerToAttach))
        {
            Instantiate(layerStorage.onionPlayers[numberOfLayers + 1], layerToAttach.transform.position, layerToAttach.transform.rotation);
            Destroy(gameObject);
            Destroy(layerToAttach);
        }
    }

    private bool isSpaceOnTop()
    {
        // TODO: replace with actual physics query
        return true;
    }

    private GameObject FindNearestEligibleLayer()
    {
        GameObject[] layers = GameObject.FindGameObjectsWithTag("OnionLayer");
        GameObject nearestEligibleLayer = null;
        float distanceToNearestEligibleLayer = float.MaxValue;

        foreach (GameObject layer in layers)
        {
            if (layer.GetComponent<OnionLayer>().layerSize == numberOfLayers + 1)
            {
                float distance = (transform.position - layer.transform.position).magnitude;
                if (distance < distanceToNearestEligibleLayer)
                {
                    nearestEligibleLayer = layer;
                    distanceToNearestEligibleLayer = distance;
                }
            }
        }
        return nearestEligibleLayer;
    }


    private bool IsLayerToAttachCloseEnough(GameObject layerToAttach)
    {
        float distance = (transform.position - layerToAttach.transform.position).magnitude;
        float radius = GetComponent<CircleCollider2D>().radius;
        float layerToAttachRadius = layerToAttach.GetComponent<CircleCollider2D>().radius;
        return distance < radius + layerToAttachRadius + epsilonForAttachingDistance;
    }

}
