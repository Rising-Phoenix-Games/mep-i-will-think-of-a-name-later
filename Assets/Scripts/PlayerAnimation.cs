using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
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
        if (Input.GetKeyDown("space")) {
            Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
        if (Input.GetButtonDown("Fire1")) {
            if (((Camera.main.ScreenToViewportPoint(Input.mousePosition).y) > 0) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) < Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f))) { //moving up
                facing = 1;
                Debug.Log((Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) + "<" + Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)));

            }

            if (((Camera.main.ScreenToViewportPoint(Input.mousePosition).y) < 0) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) > Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f))) { //moving down
                Debug.Log((Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) + ">" + Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)));
                facing = 2;
            }

            if (((Camera.main.ScreenToViewportPoint(Input.mousePosition).x) < 0) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) < Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f))) { //moving left
                Debug.Log((Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) + "<" + Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)));
                facing = 3;
            }

            if (((Camera.main.ScreenToViewportPoint(Input.mousePosition).x) > 0) && (Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) > Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f))) { //moving right
                Debug.Log((Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f) + ">" + Mathf.Abs(Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f)));
                facing = 4;
            }
        }
        if (Input.GetButton("Fire2")&&Time.time > attackTime) {
  	        attackTime = Time.time + attackDuration;
            playerAnim.SetTrigger("attack");
        }

      playerAnim.SetInteger("facing", facing);

    }
}
