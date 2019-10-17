using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordData;

public class FollowShoot : MonoBehaviour
{
    public GameObject player;
    // public float movementRangeMax;
    // public float movementRangeMin;
    // public float speed;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //movement(movementRangeMin, movementRangeMax);
        
    }

    public void movement(float movementRangeMin, float movementRangeMax, float speed) {
        Vector2 originalEnemyPosition = transform.position;
		
        if (((Vector2.Distance(transform.position, player.transform.position) < movementRangeMax) &&
            (Vector2.Distance(transform.position, player.transform.position) > movementRangeMin)) &&
            !GameObject.Find("UI").GetComponent<PauseStuff>().paused) {

			transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed*Time.deltaTime);
			
            

            gameObject.SendMessage("updateMovementAnim", originalEnemyPosition, SendMessageOptions.DontRequireReceiver);
		}
		//testEnemyMageAnim.SetInteger("testEnemyMageFacing", testEnemyMageDirection);
	}

    public void shoot(float shootRangeMax, float shootRangeMin, float nextFire, float fireRate){

        if ((((Vector2.Distance(transform.position, player.transform.position) < shootRangeMax) &&
            (Vector2.Distance(transform.position, player.transform.position) > shootRangeMin)) &&
            (Time.time > nextFire)) && !GameObject.Find("UI").GetComponent<PauseStuff>().paused)
        {
            //nextFire = Time.time + fireRate;
            gameObject.SendMessage("fireProjectile", player, SendMessageOptions.DontRequireReceiver);
        }

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            gameObject.SendMessage("dealMeleeDamage", collider.gameObject, SendMessageOptions.DontRequireReceiver);

        }
    }

    void death(int health) {
        if (health <= 0) {
            this.SendMessage("die", SendMessageOptions.DontRequireReceiver);
            this.enabled = false;
        }
    }
}