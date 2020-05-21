using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_TwoD_Bomb : MonoBehaviour
{
    Spawner_Boom_Enemies spawnerHerePls;
    public float speed;
    float copySpeedValue;
    //GameObject mydoor;
    public string tagToFind;
    float timerToDie = 1.5f;

    //MeshRenderer myMeshBomb; 
     bool ispatrolling;

    bool isChasing;
    bool isAttached;
    bool isThrowedByPlayer;
    bool isAalive;
    public bool moveRight;
    public GameObject cannon;
    public bool spawned;
    public Rigidbody2D rb;
    public bool isfalling;
    public SpriteRenderer myRenderedSprite;

    float waitUntilSpawn;
    public  PlayerMagnet playerRef;
    float timerFalling = 3f;

    float minDistance;
    private float range;
    public Transform player;
    bool explosioning;
    bool grounded = false;
    float breakableTimer;

    public bool breakableDoor = false;
    
   // bool isthrowing;
///
    float explosionTimer; // la muerte;
    float innerEplsionRange;
    Vector2 addPositiveForce = new Vector2 (3,3);
    Vector2 addNegativeForce = new Vector2(-3, 3);

    // Start is called before the first frame update
    void Start()
    {
        minDistance = 2f;
        ispatrolling = false;
        isChasing = false;
       // isthrowing = false;
        isAttached = false;
        rb.isKinematic = true;
        copySpeedValue = speed;
        isAalive = false;
        explosionTimer = 0.6f;
       //spawnerHerePls = GameObject.FindGameObjectWithTag (tagToFind).GetComponent<Spawner_Boom_Enemies>();
        waitUntilSpawn = 0.8f;
        CheckTagFromSpawner();
        spawned = true;
        //myMeshBomb = gameObject.GetComponent<MeshRenderer>();
        myRenderedSprite = gameObject.GetComponent<SpriteRenderer>();
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMagnet>();
        //cannon = GameObject.Find("cannon");
        // rb =gameObject.GetComponent<Rigidbody2D>();
        innerEplsionRange = 1f;
        explosioning = false;
        //mydoor = GameObject.FindGameObjectWithTag("BreakableDoor");
        breakableTimer = 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (spawned == true)
        {
           
            if (!grounded && isThrowedByPlayer == false && isAttached == false)
            {

                isfalling = true;
            }
            if (isfalling)
            {
               
                rb.isKinematic = false;
               
            }
          

            if (!isAttached && !isThrowedByPlayer && !isfalling)
            {
                
                player = GameObject.FindWithTag("Player").transform;
                range = Vector2.Distance(transform.position, player.position);
          


                if (range <= minDistance)
                {
                    isChasing = true;
                    ispatrolling = false;
                    player = GameObject.FindWithTag("Player").transform;
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    explosionTimer -= Time.deltaTime;
                    if(explosionTimer <= 0)
                    {
                        explosioning = true;
                    }
                   // Debug.Log("esta en rango");
                }
                if (range > minDistance)
                {
                    isChasing = false;
                    ispatrolling = true;

                   // Debug.Log("entra en fuera de rango " + isChasing + " es faslse " + "ispatroll = " + ispatrolling);


                }

                  

                    

                

                if (ispatrolling)
                {
                    if (moveRight)
                    {
                        transform.Translate(2 * Time.deltaTime * speed, 0, 0);

                    }
                    else
                    {
                        transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                    }
                }
       
            }
          
             if (isAttached)
              {
                  speed = 0;
                  
                  isChasing = false;
                  ispatrolling = false;
                  isThrowedByPlayer = false;
                rb.isKinematic = true;
                Vector3 l_Direction = cannon.transform.position; 
                transform.position = l_Direction ;
                transform.parent = cannon.transform;
                
             
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

                CheckifEnemyShooted();
            }
            
             if(isThrowedByPlayer == true)
            {
                transform.parent = null;
                rb.isKinematic = false;
               
                isAttached = false;
                AddforceThrow();
                timerToDie -= Time.deltaTime;
                breakableTimer -= Time.deltaTime;
                Debug.Log(breakableTimer);


                if(breakableTimer > 0 && isThrowedByPlayer == true)
                {
                    breakableDoor = true;
                }
                if(breakableTimer <= 0)
                {
                    breakableDoor = false;
                }
                Debug.Log("breakable door " + breakableDoor);

                if(timerToDie <= 0)
                {
                    Debug.Log("entra en timer to die <0");
                    timerToDie = 1.5f;
                    isThrowedByPlayer = false;
                    ResetValues();
                   
                    //callSpawner();
                }
                

            }
            if (!grounded && isAttached == false)
            {
                timerFalling -= Time.deltaTime;

                if(timerFalling <= 0)
                {
                    timerFalling = 3f;
                    ResetValues();
                }
            }

            if(explosioning == true)
            {
                //explosionTimer -= Time.deltaTime;
                  //  if (explosionTimer <= 0)
                   // {
                       // if (range <= innerEplsionRange && isAttached == false && isThrowedByPlayer == false)
                       // {

              
                            Destroy(player.gameObject);
                        //}
                      
                     spawned = false;
                     explosionTimer = 0.6f;
                     ResetValues();

                    //}

              }

        }
        else
        {
            waitUntilSpawn -= Time.deltaTime;
           
           
            if(waitUntilSpawn <= 0)
            {
                ResetValues();

            }
        }
    }
    private void ResetValues()
    {
        Debug.Log("entra en reset tras el tiro");
        transform.position = spawnerHerePls.transform.position;
        speed = copySpeedValue;
       
        myRenderedSprite.enabled = true;
        // myMeshBomb.enabled = true;
        waitUntilSpawn = 0.8f;
        //CheckTagFromSpawner();
        ispatrolling = false;
        isChasing = false;

        isAttached = false;
        isThrowedByPlayer = false;
       
        grounded = false;
        spawned = true;
        rb.isKinematic = false;
        rb.AddForce(new Vector2(0, 0));
        explosioning = false;




    }


    void callSpawner()
    {
        spawnerHerePls.EnemyFell(true);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && isThrowedByPlayer == false)
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
        if (collision.gameObject.CompareTag("Wall") && isThrowedByPlayer == true || collision.gameObject.CompareTag("Ground") && isThrowedByPlayer == true )
        {
           
            
            spawned = false;
            ResetValues();
           

        }

       

        if (collision.gameObject.tag == "BreakableDoor" )
        {
            
            spawned = false;
            ResetValues();

        }




        if (collision.gameObject.CompareTag("Ground"))
        {
            isfalling = false;
            grounded = true;
        
          
          
        }
        if (collision.gameObject.tag =="Player")
        {
            isAttached = true;
        }
    }

    void CheckTagFromSpawner()
    {
        if (spawnerHerePls.negativeDirection)
        {
            moveRight = false;
        }
        else
        {
            moveRight = true;
        }
    }

    void CheckifEnemyShooted() 
    {
        if(playerRef.keyPressed == "Pressed" && isAttached == true && isThrowedByPlayer == false )
        {
            Debug.Log("DISPARA");
   
            isAttached = false;
            isThrowedByPlayer = true;
        }
    }

    void AddforceThrow()
    {
       if (myRenderedSprite.GetComponent<SpriteRenderer>().flipX)
        {
            rb.AddForce(addPositiveForce, ForceMode2D.Impulse); // POSITIVO
        }
        else
        {

            rb.AddForce(addNegativeForce, ForceMode2D.Impulse); // NEGATIVO
        }
       
    }   
    
    
}
