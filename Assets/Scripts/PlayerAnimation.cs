using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public int facing;
    public float attackTime;
    public float attackDuration;


    // Start is called before the first frame update
    void Start()
    {
      playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if ((Input.GetAxis("Vertical")) > 0) { //moving up
          facing = 1;
      }

      if ((Input.GetAxis("Vertical")) < 0) { //moving down
          facing = 2;
      }

      if ((Input.GetAxis("Horizontal")) < 0) { //moving left
          facing = 3;
      }

      if ((Input.GetAxis("Horizontal")) > 0) { //moving right
          facing = 4;
      }

      if (Input.GetButton("Fire1")&&Time.time > attackTime) {
  			   attackTime = Time.time + attackDuration;
           playerAnim.SetTrigger("attack");
      }

      playerAnim.SetInteger("facing", facing);

    }
}
