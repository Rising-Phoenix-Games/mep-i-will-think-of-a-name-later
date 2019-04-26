using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordData;

public class slash : MonoBehaviour
{
    public GameObject target;
    public bool canHit = false;

    MeleeAttack swordSlash;
    // Start is called before the first frame update
    void Start()
    {
        swordSlash = new MeleeAttack(Wooden.damage, Wooden.knockback, GameObject.FindGameObjectWithTag("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            target = collider.gameObject;
            canHit = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        canHit = false;
    }

    public void dealDamage(GameObject target)
    {
        if (canHit)
        {
            target.SendMessage("takeMeleeDamage", swordSlash, SendMessageOptions.DontRequireReceiver);
        }
    }
}
