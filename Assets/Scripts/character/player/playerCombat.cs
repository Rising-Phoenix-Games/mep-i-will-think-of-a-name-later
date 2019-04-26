using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCombat : MonoBehaviour
{
    //Health take damage stuff
    public int maxHealth = 100;
    public int health;
    public bool isDead = false;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
 	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
 	bool damaged;
	public Image damageImage;

    //HP Bar slider thing
    public Slider HPBar;

    //Scripts to disable on death
    playerAnimation playerAnimation;
    playerMovement playerMovement;

    //Other random stuff
    public bool godMode;
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<playerAnimation>();
        playerMovement = GetComponent<playerMovement>();

        playerAnim = GetComponent<Animator>();

        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(damaged) {
			 //damageImage.color = flashColour; // ... set the colour of the damageImage to the flash colour.
		}
		else {
			 //	damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime); // ... transition the colour back to clear.
		}
		damaged = false; // Reset the damaged flag.

		if (godMode) {
			health = 100;
		}


        HPBar.value = health;
    }

    public void takeDamage (int amount){
		int damageamount = amount;
		damaged = true;
	    health -= damageamount;
	 	if(health <= 0 && !isDead)
        {
   			Death ();
        } else {
            playerAnim.Play("take damage");
		}

	}

	void Death (){
		// Set the death flag so this function won't be called again.
	  isDead = true;

	  // Tell the animator that the player is dead.
	  playerAnim.Play("KnightDead");

	  // Turn off the movement script.
	  playerMovement.enabled = false;
      playerAnimation.enabled = false;
	}
}
