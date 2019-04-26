using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordData;

public class skeletonBasic : MonoBehaviour
{
    public int health = 25;
    public int touchDamage = 10;
    Rigidbody2D skeleBody;

    // Start is called before the first frame update
    void Start()
    {
        skeleBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeMeleeDamage(MeleeAttack meleeAttack)
    {
        health -= meleeAttack.damage;

        
        Vector2 moveDirection = skeleBody.transform.position - meleeAttack.player.transform.position;
        skeleBody.AddForce(moveDirection.normalized * -500f);

        Debug.Log("You did: " + meleeAttack.damage + " damage");

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
        this.enabled = false;
    }
}
