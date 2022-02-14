using UnityEngine;

public class OnionLayerManager : MonoBehaviour
{
    public int numberOfLayers;
    private OnionLayerStorage layerStorage;
    private static float epsilonForAttaching = 0.1f;

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
        if (numberOfLayers > 0) // TODO: check that there are no obstacles
        {
            Instantiate(layerStorage.onionLayers[numberOfLayers], transform.position, Quaternion.identity);
            Instantiate(layerStorage.onionPlayers[numberOfLayers - 1], transform.position + Vector3.up * 2, Quaternion.identity);
            AkSoundEngine.PostEvent("play_player_loco_pop_in", gameObject); //wwise
            Destroy(gameObject);

        }
    }

    private void AttemptAttach()
    {
        GameObject layerToAttach = FindNearestEligibleLayer();
        if (layerToAttach != null && IsLayerToAttachCloseEnough(layerToAttach)) // TODO: check that there are no obstacles
        {
            Instantiate(layerStorage.onionPlayers[numberOfLayers + 1], layerToAttach.transform.position, Quaternion.identity);
            Destroy(gameObject);
            AkSoundEngine.PostEvent("play_player_loco_pop_out", gameObject);  //wwise
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
        return Physics2D.Distance(GetComponent<Collider2D>(), layerToAttach.GetComponent<Collider2D>()).distance < epsilonForAttaching;
    }

}
