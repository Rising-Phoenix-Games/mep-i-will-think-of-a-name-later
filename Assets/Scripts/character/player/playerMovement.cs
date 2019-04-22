using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    Vector2 endPos;
    playerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<playerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimation.movementAnim();
        if (Input.GetButton("Fire1")) {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime * 5);

    }
}
