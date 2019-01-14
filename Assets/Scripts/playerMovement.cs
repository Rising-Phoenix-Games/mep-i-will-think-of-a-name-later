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
        if (Input.GetButton("Fire1")) {
            startPos = transform.position;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //movement(startPos, endPos, speed);
            playerAnimation.movementAnim();

        }
        transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime * 5);

    }

    private IEnumerator movement(Vector2 startPos, Vector2 endPos, float speed)
    {
        float i = 0;
        while ((transform.position.x != endPos.x) || (transform.position.y != endPos.y))
        {
            i += speed;
        }
        yield return new WaitForEndOfFrame();
    }
}
