using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using swordData;

public class slash : MonoBehaviour
{
    public GameObject target;
    public bool canHit = false;
    // Start is called before the first frame update
    void Start()
    {
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
            target.SendMessage("dealDamage", wooden.damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
