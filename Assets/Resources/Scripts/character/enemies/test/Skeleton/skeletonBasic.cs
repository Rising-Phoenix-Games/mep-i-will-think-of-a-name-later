using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordData;

public class skeletonBasic : MonoBehaviour
{
    public int health;
    public int touchDamage;
    public float speed;
    Rigidbody2D skeleBody;
    FollowTouch FollowTouch;
    public float movementRangeMax;
    public float movementRangeMin;

    // Start is called before the first frame update
    void Start()
    {
        skeleBody = GetComponent<Rigidbody2D>();
        FollowTouch = GetComponent<FollowTouch>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTouch.movement(movementRangeMin, movementRangeMax, speed);
    }

    void updateMovementAnim(Vector2 originalPos) {

        this.GetComponent<Animator>().SetFloat("y", transform.position.y - originalPos.y);
        this.GetComponent<Animator>().SetFloat("x", transform.position.x - originalPos.x);
    }

    void takeMeleeDamage(MeleeAttack meleeAttack)
    {
        health -= meleeAttack.damage;

        
        Vector2 moveDirection = skeleBody.transform.position - meleeAttack.player.transform.position;
        skeleBody.AddForce(moveDirection.normalized * -500f);

        Debug.Log("You did: " + meleeAttack.damage + " damage to: " + this.gameObject.name);

        if (health <= 0) {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90f);
            this.SendMessage("death", health, SendMessageOptions.DontRequireReceiver);
            this.enabled = false;
        }
    }

    void dealMeleeDamage(GameObject player) {
        player.GetComponent<playerCombat>().takeDamage(touchDamage);
    }

    void die() {
        Debug.Log(this.gameObject.name + " has died, oof");
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        
    }
}
