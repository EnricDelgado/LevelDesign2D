using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offset = 0;
    public float XOffset, YOffset;
    Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = PlayerTransform.position.x;
        temp.x += offset;

        temp.y = PlayerTransform.position.y;
        temp.x += offset;

        // if((transform.position - PlayerTransform.position).magnitude > offset)
        //     Vector3.MoveTowards(transform.position, PlayerTransform.position, offset);

        transform.position = temp;
    }
}
