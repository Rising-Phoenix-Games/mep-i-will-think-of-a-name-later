using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Animator projectileAnim;
	public float speed;
	public Vector2 direction;
	public float maxRange;
	public int damage;

	// Use this for initialization
	void Start () {
		projectileAnim = GetComponent<Animator>();
		damage = 5;
	}

    public void setDirection(Vector2 directionToBeSet) {
        direction = directionToBeSet;
    }

	// Update is called once per frame
	void Update () {
		if (direction != Vector2.zero) {
		transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
		}
		else {
		Debug.LogError(this.gameObject.name + " lacks a direction!");
		DestroyImmediate(this);
		}
		if (Vector2.Distance(transform.position, GameObject.FindWithTag("Player").transform.position)>maxRange) {
				Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)	{
		if (/*collision.gameObject.CompareTag("Platform")||*/collision.gameObject.CompareTag("Player")) {
			if (collision.gameObject.CompareTag("Player")) {
				GameObject.FindWithTag("Player").GetComponent<playerCombat>().takeDamage(damage);;
			}
			projectileAnim.SetTrigger("collision");
			Destroy(this.gameObject);
		}
	}
}
