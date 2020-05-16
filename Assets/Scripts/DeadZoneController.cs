using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().HP = 0;
    }
}
