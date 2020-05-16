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
            Debug.Log("IF entered");
            isRunning = true;
            Debug.Log("Entering corroutine");
            StartCoroutine(DisplayLaser(Laser));
        }
    }

    IEnumerator DisplayLaser(GameObject laser)
    {
        Debug.Log("Running Corroutine");
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        laser.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        laser.gameObject.SetActive(true);
        isRunning = false;
        Debug.Log("Ending corroutine");
    }
}