using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float HP = 100;

    void Update()
    {
        if(HP <= 0)
            Destroy(gameObject);
    }
}
