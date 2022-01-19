using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionLayerManager : MonoBehaviour
{
    public int numberOfLayers;
    private OnionLayerStorage layerStorage;
    private static float epsilonForAttaching = 0.1f;
    private static float epsilonForDetaching = 0.1f;

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
        if (numberOfLayers > 0)
        {
            float radius = GetComponent<CircleCollider2D>().radius;
            float innerRadius = layerStorage.onionPlayers[numberOfLayers - 1].GetComponent<CircleCollider2D>().radius;
            Vector3 spawnPosition = transform.position + Vector3.up * (radius + innerRadius + epsilonForDetaching);
            Collider2D overlap = Physics2D.OverlapCircle(spawnPosition, innerRadius);

            if (overlap == null)
            {
                Instantiate(layerStorage.onionLayers[numberOfLayers], transform.position, transform.rotation);
                Instantiate(layerStorage.onionPlayers[numberOfLayers - 1], spawnPosition, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                GameObject overlapGameObject = overlap.gameObject;
                Debug.Log("Can't detach layer, the " + overlapGameObject.name + " is in the way");
            }
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
        return distance < radius + layerToAttachRadius + epsilonForAttaching;
    }

}
