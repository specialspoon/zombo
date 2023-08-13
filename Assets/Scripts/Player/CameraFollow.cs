using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    public float smoothTime = 1f;
    private Vector2 velocity = Vector2.zero;
    public float z_position = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z_position);

        Vector3 targetPosition = player.TransformPoint(new Vector3(0, 0, -10));

        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
