using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_TwoD : MonoBehaviour

{
    public float bulletSpeed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed * 10 * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player" || collision.gameObject.tag =="Wall" || collision.gameObject.tag =="Ground" || collision.gameObject.tag =="BreakableDoor" || collision.gameObject.tag == "EnemyBomb")
        Destroy(this.gameObject);
        
    }
}
