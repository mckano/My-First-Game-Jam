using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minX;

    void Update()
    {
        GameObject target = GameObject.FindWithTag("Player");
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Max(minX, target.transform.position.x);
        transform.position = newPosition;
    }
}
