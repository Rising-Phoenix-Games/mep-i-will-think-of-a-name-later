using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    GameObject slash;

    playerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        slash = GameObject.FindWithTag("playerAttack");
        playerAnimation = GetComponent<playerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time > playerAnimation.attackTime)
        {
            
        }
    }
}
