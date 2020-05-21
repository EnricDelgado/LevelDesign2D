using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Boom_Enemies : MonoBehaviour
{
    public Transform pointShoot;
    public GameObject enemyBomb;

    public bool negativeDirection;
    public bool enemyDown;

    Patrol_TwoD_Bomb _myEnemyBombPatrol;

   //private GameObject[] booms = new GameObject [3];
    // Start is called before the first frame update
    void Start()
    {
      //  AddBoombsTOSPAWNER(booms);
        enemyDown = false;
        _myEnemyBombPatrol =  FindObjectOfType<Patrol_TwoD_Bomb>().GetComponent<Patrol_TwoD_Bomb>();

    }

    // Update is called once per frame
    void Update()
    {
        //check if onSCreen ?'?
        Debug.Log("enemy down es:" + enemyDown);
        /*if(enemyDown == true)
        {
            SpawnEnemyBomb();
        }*/

    }

   private void SpawnEnemyBomb()
    {
        
        Instantiate(enemyBomb, pointShoot.position, pointShoot.rotation);
        enemyDown = false;
    }

    public void EnemyFell (bool AreUSerious)
    {

        enemyDown = AreUSerious;
    }

    void AddBoombsTOSPAWNER( GameObject [] arrrayTofillHere)
    {
        for (int i = 0; i <= arrrayTofillHere.Length; i++)
        {
            arrrayTofillHere[i] = enemyBomb;
        }
    }

    void AddTagToEveryBomb()
    {

    }
}
