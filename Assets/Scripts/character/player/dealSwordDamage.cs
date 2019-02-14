using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using swordData;

public class dealSwordDamage : MonoBehaviour
{
    Collider2D enemyThing;


    playerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<playerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}