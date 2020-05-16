using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float HP = 100;
    public Vector3 CheckPoint = new Vector3();

    void Start() {
        CheckPoint = transform.position;
    }

    void Update()
    {
        CheckPlayerDeath();
    }

    void CheckPlayerDeath()
    {
        if(HP <= 0)
        {
            transform.position = CheckPoint;
            HP = 100;
            StartCoroutine(PlayerCooldown());
        }
    }

    IEnumerator PlayerCooldown()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        float initialSpeed = Player.GetComponent<PlayerMovement>().runSpeed;
        float initialJumpF = Player.GetComponent<CharacterController2D>().m_JumpForce;

        Player.GetComponent<PlayerMovement>().runSpeed = 0;
        Player.GetComponent<CharacterController2D>().m_JumpForce = 0;

        yield return new WaitForSeconds(.5f);

        Player.GetComponent<PlayerMovement>().runSpeed = initialSpeed;
        Player.GetComponent<CharacterController2D>().m_JumpForce = initialJumpF;
    }
}
