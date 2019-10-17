using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordData;

public class demonBasic : MonoBehaviour
{
    public int health;
    public int touchDamage;
    public float fireRate;
    private float nextFire = 0.0F;
    public float speed;
    Rigidbody2D demonBody;
    FollowShoot FollowShoot;
    public float movementRangeMax;
    public float movementRangeMin;
    public float shootRangeMax;
    public float shootRangeMin;
    public bool canDealMeleeDamage;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        demonBody = GetComponent<Rigidbody2D>();
        FollowShoot = GetComponent<FollowShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowShoot.movement(movementRangeMin, movementRangeMax, speed);
        FollowShoot.shoot(shootRangeMax, shootRangeMin, nextFire, fireRate);
    }

    void updateMovementAnim(Vector2 originalPos) {

        this.GetComponent<Animator>().SetFloat("y", transform.position.y - originalPos.y);
        this.GetComponent<Animator>().SetFloat("x", transform.position.x - originalPos.x);
    }

    void takeMeleeDamage(MeleeAttack meleeAttack)
    {
        health -= meleeAttack.damage;

        
        Vector2 moveDirection = demonBody.transform.position - meleeAttack.player.transform.position;
        demonBody.AddForce(moveDirection.normalized * -500f);

        Debug.Log("You did: " + meleeAttack.damage + " damage to: " + this.gameObject.name);

        if (health <= 0) {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90f);
            this.SendMessage("death", health, SendMessageOptions.DontRequireReceiver);
            this.enabled = false;
        }
    }

    void fireProjectile(GameObject target) {

        nextFire = Time.time + fireRate;

        this.GetComponent<Animator>().SetTrigger("attacking");

        Vector2 heading = target.transform.position - this.transform.position;
        Vector2 direction = heading / heading.magnitude;
        Vector3 diff = target.transform.position - this.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        GameObject firedProjectile = Instantiate(projectilePrefab, (Vector2)transform.position, Quaternion.Euler(0f, 0f, 180 + rot_z));
        firedProjectile.SendMessage("setDirection", direction, SendMessageOptions.DontRequireReceiver);
    }

    void dealMeleeDamage(GameObject player) {
        if (canDealMeleeDamage) {
            player.GetComponent<playerCombat>().takeDamage(touchDamage);
        }
    }

    void die() {
        Debug.Log(this.gameObject.name + " has died, oof");
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        
    }
}