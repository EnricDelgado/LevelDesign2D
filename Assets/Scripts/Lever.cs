using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool doorOpen;
    public GameObject door;
    public float initPos;

    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        initPos = door.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen == true)
        {
            if (door.transform.position.y < initPos + 5)
            {
                door.transform.position += new Vector3(0, 0.1f, 0);
            }
            else Debug.Log("Arrived");
            
        }
    }
}
