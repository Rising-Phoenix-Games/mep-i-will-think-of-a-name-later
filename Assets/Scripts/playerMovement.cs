using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 startPos;
    public Vector2 endPos;
    playerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<playerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            startPos = transform.position;
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
            endPos = transform.position;
            playerAnimation.MovementAnim();
        }
    }
}
