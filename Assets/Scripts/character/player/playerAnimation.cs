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
    slash slash;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        slash = GameObject.FindGameObjectWithTag("playerAttack").GetComponent<slash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2")&&Time.time > attackTime)
        {
  	        attackTime = Time.time + attackDuration;
            playerAnim.SetTrigger("attack");
            
            slash.dealDamage(slash.target);
        }
        
    }

    public void movementAnim(Vector2 startPos, Vector2 endPos)
    {
        float slope = (endPos.y - startPos.y) / (endPos.x - startPos.x);

        if (((slope >= 0.5625) || (slope <= -0.5625)) && (endPos.y < 0.5f))
        {   //moving up
            //insert joke about moving up in the world here
            facing = 1;
        }

        else if (((slope >= 0.5625) || (slope <= -0.5625)) && (endPos.y > 0.5f))
        {   //moving down
            facing = 2;
        }

        if (!((slope >= 0.5625) || (slope <= -0.5625)) && (endPos.x < 0.5f))
        {   //moving left
            facing = 3;
        }

        else if (!((slope >= 0.5625) || (slope <= -0.5625)) && (endPos.x > 0.5f))
        {   //moving right
            facing = 4;
        }

        float direction = 0;
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
        playerAnim.SetInteger("facing", facing);
        GameObject.FindGameObjectWithTag("playerAttack").transform.rotation = Quaternion.Euler(0, 0, direction);
    }
}
