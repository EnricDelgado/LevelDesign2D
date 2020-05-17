using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableDoorController : MonoBehaviour
{
    public GameObject Door;
    public float RotationSpeed = .3f;
    public float RotationFactor = -60;
    public float ClosingTime = 3f;

    bool OpenDoor = false, CloseDoor = false;

    private void Update() 
    {
        if(OpenDoor)
        {
            //Debug.Log("Opening Door");
            Door.transform.rotation = Quaternion.Lerp(Door.transform.rotation, Quaternion.Euler(0, 0, RotationFactor), RotationSpeed * Time.deltaTime);

            StartCoroutine(CloseDoorRoutine(ClosingTime));
        }

        if(CloseDoor)
        {
            Door.transform.rotation = Quaternion.Lerp(Door.transform.rotation, Quaternion.Euler(0, 0, 0), RotationSpeed * Time.deltaTime);
            CloseDoor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            OpenDoor = true;
        }
    }

    IEnumerator CloseDoorRoutine(float Time)
    {
        yield return new WaitForSeconds(Time);
        OpenDoor = false;
        CloseDoor = true;
    }
}
