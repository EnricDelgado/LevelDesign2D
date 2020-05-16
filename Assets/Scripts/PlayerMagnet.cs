using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public GameObject PlayerMgt;
    public int RaycastDistance;
    public LayerMask RaycastMask;

    void Update()
    {
        FaceMouse(PlayerMgt);
        Vector2 MouseCoord = Input.mousePosition;
        MouseCoord = Camera.main.ScreenToWorldPoint(MouseCoord);

        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast( ray, out hit, RaycastDistance) )
            {
                Debug.Log("Clicking" + hit.transform.gameObject.name);
            }

            if(CheckTarget())
            {
                Debug.Log("Enable attractor");
            }

            Debug.Log("Not clicking magnet");
        }
    }

    void FaceMouse(GameObject PlayerMagnet)
    {
        Vector2 MouseCoord = Input.mousePosition;
        MouseCoord = Camera.main.ScreenToWorldPoint(MouseCoord);

        Vector2 Dir = MouseCoord - new Vector2(PlayerMgt.transform.position.x, PlayerMgt.transform.position.y);

        PlayerMgt.transform.right   = Dir;

        // Vector2 Dir = Input.mousePosition - Camera.main.ScreenToWorldPoint(PlayerMgt.transform.position);;
        // float Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;

        // PlayerMgt.transform.up = Dir;
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
        }
        return false;
    }
}