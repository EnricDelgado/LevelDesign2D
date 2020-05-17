using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public GameObject PlayerMgt;
    public GameObject TargetMagnet;
    public int RaycastDistance;
    public LayerMask RaycastMask;
    public Lever lever;

    AreaEffector2D TargetEffector;

    void Start()
    {
        TargetEffector = TargetMagnet.GetComponentInChildren<AreaEffector2D>();
        TargetEffector.enabled = true;
    }

    void Update()
    {
        FaceMouse(PlayerMgt);
        Vector2 MouseCoord = Input.mousePosition;
        MouseCoord = Camera.main.ScreenToWorldPoint(MouseCoord);

        if(Input.GetMouseButton(0))
        {
            if(CheckTarget())
            {
                TargetEffector.enabled = true;
            }

        }
        else
        {
            TargetEffector.enabled = false;
        }
    }

    void FaceMouse(GameObject PlayerMagnet)
    {
        Vector2 MouseCoord = Input.mousePosition;
        MouseCoord = Camera.main.ScreenToWorldPoint(MouseCoord);

        Vector2 Dir = MouseCoord - new Vector2(PlayerMgt.transform.position.x, PlayerMgt.transform.position.y);

        PlayerMgt.transform.right   = Dir;
    }

    bool CheckTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, RaycastDistance, RaycastMask))
        {
            if(hit.transform.gameObject.tag == "TargetMagnet")
            {
                return true;
            }

            if (hit.transform.gameObject.GetComponent<Lever>())
            {
                Debug.Log("Lever");
                lever = hit.transform.gameObject.GetComponent<Lever>();
                lever.doorOpen = true;
            }
        }
        return false;
    }
}