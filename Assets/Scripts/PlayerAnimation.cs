using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public int facing;
    public float attackTime;
    public float attackDuration;
    playerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerMovement = GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
        
        if (Input.GetButton("Fire2")&&Time.time > attackTime) {
  	        attackTime = Time.time + attackDuration;
            playerAnim.SetTrigger("attack");
        }

      playerAnim.SetInteger("facing", facing);

    }

    public void MovementAnim()
    {
        float slope = playerMovement.endPos.y - playerMovement.startPos.y - (playerMovement.endPos.x - playerMovement.startPos.x);

        if (!((slope >= 1) || (slope >= -1)) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) < Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)))
        { //moving up
            facing = 1;
        }

        if (((slope >= 1) || (slope >= -1)) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) < Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)))
        { //moving down
            facing = 2;
        }

        if (((slope >= 1) || (slope >= -1)) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) > Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)))
        {   //moving left
            facing = 3;
        }

        if (!((slope >= 1) || (slope >= -1)) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) > Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)))
        { //moving right
            facing = 4;
        }
    }
}
