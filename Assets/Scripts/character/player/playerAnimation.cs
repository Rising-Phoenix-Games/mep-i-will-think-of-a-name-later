using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using swordData;

public class playerAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public int facing;
    public float attackTime;
    public float attackDuration;
    playerMovement playerMovement;
    slash slash;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerMovement = GetComponent<playerMovement>();
        slash = GameObject.FindGameObjectWithTag("playerAttack").GetComponent<slash>();
    }

    // Update is called once per frame
    void Update()
    {   float direction = 0;
        switch (facing)
        {
            case 1:
                direction = 0f;
                break;
            case 2:
                direction = 180f;
                break;
            case 3:
                direction = -90f;
                break;
            case 4:
                direction = 90f;
                break;
        }
        GameObject.FindGameObjectWithTag("playerAttack").transform.rotation = Quaternion.Euler(0, 0, direction);

        if (Input.GetButton("Fire2")&&Time.time > attackTime)
        {
  	        attackTime = Time.time + attackDuration;
            playerAnim.SetTrigger("attack");
            
            slash.dealDamage(slash.target);
        }
        
        playerAnim.SetInteger("facing", facing);

    }

    public void movementAnim()
    {
        float slope = (playerMovement.endPos.y - playerMovement.startPos.y) / (playerMovement.endPos.x - playerMovement.startPos.x);

        if (((slope >= 0.5625) || (slope <= -0.5625)) && (playerMovement.endPos.y < 0.5f))
        {   //moving up
            //insert joke about moving up in the world here
            facing = 1;
        }

        else if (((slope >= 0.5625) || (slope <= -0.5625)) && (playerMovement.endPos.y > 0.5f))
        {   //moving down
            facing = 2;
        }

        if (!((slope >= 0.5625) || (slope <= -0.5625)) && (playerMovement.endPos.x < 0.5f))
        {   //moving left
            facing = 3;
        }

        else if (!((slope >= 0.5625) || (slope <= -0.5625)) && (playerMovement.endPos.x > 0.5f))
        {   //moving right
            facing = 4;
        }
    }
}
