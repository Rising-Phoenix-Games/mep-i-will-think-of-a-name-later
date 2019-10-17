using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordData;

public class dummy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dealMeleeDamage(MeleeAttack meleeAttack)
    {
        Debug.Log("You did: " + meleeAttack.damage + " damage");
    }
}
