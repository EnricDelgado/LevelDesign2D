using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableDoorController : MonoBehaviour
{
    public int RaycastDistance;
    public LayerMask RaycastMask;

    GameObject currentDoor;

    private void Start() {
        currentDoor = null;
    }

    private void Update() 
    {

        Vector2 MouseCoord = Input.mousePosition;
        MouseCoord = Camera.main.ScreenToWorldPoint(MouseCoord);

        if(Input.GetMouseButton(0))
        {
            Debug.Log("Got target: " + CheckTarget());

            if(CheckTarget())
            {
                Debug.Log("Attach door");

                if(currentDoor != null) currentDoor.transform.SetParent(this.gameObject.transform);
            }

        }
        else
        {
            if(currentDoor != null)
            {
                Debug.Log("Detach door");

                currentDoor.transform.parent = null;
                currentDoor = null;
            }
        }
    }

    bool CheckTarget()
    {
        Debug.Log("Entering CheckTarget");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, RaycastDistance))
        {
            Debug.Log("Raycast hitting: " + hit.transform.gameObject.name);

            if(hit.transform.gameObject.tag == "MovableDoor")
            {
                Debug.Log("Door hitted");
                currentDoor = hit.transform.gameObject;
                return true;
            }
        }
        return false;
    }
}
