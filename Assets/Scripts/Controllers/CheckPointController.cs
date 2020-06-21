using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    Vector3 checkPointPos = new Vector3();

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().CheckPoint = this.transform.position;
    }
}
