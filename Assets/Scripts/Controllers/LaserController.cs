using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject Laser;
    public bool isRunning;

    void Start() 
    {
        isRunning = false;    
    }

    void Update()
    {
        if(!isRunning)
        {
            isRunning = true;
            StartCoroutine(DisplayLaser(Laser));
        }
    }

    IEnumerator DisplayLaser(GameObject laser)
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        laser.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        laser.gameObject.SetActive(true);
        isRunning = false;
    }
}