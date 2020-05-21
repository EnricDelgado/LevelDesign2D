using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_TwoD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public GameObject player;
    public GameObject canon;


    public bool isDestroyable;

    public float distanciaDisparo = 10;
    public float frequency = 2;
    public int health = 2;
    private float timer;
    public Transform disparoPoint;
    private float angulo;
    /*float maxAngleLeft;
    float maxAngleRight;
    float maxAngleUp;
    float maxAngleDown;
    float minxAngleLeft;
    float minAngleRight;
    float minAngleUp;
    float minAngleDown;*/

    void Start()
    {
      /*  maxAngleLeft = 90f;
        maxAngleRight = -90f;
        maxAngleUp = -180f;
        maxAngleDown = 180f;*/
        timer = frequency;
        //player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {

        //PILLAMOS ANGULO HACIA PLAYER
        
        angulo = Mathf.Atan2(player.transform.position.y - canon.transform.position.y, player.transform.position.x - canon.transform.position.x) * Mathf.Rad2Deg - 90;

        //ROTAMOS CAÑON      

        Debug.Log(angulo);
       
       
        
        
        
        

       
        
            canon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));
        
        //DISPARAMOS
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < distanciaDisparo)
            {
             
                Instantiate(bullet, disparoPoint.position, canon.transform.rotation);
                

            }

            timer = frequency;
        }
    
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Attack") && isDestroyable == true)
        {
            health--;
        }
    }
}
