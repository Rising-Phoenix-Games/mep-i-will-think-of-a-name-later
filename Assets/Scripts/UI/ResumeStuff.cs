using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeStuff : MonoBehaviour {

	public bool paused = false;
	GameObject[] pauseThings;
    // GameObject[] enemies;
	GameObject player;
	playerMovement playerMovement;

	void Start()
	{
		player = GameObject.FindWithTag ("Player");
		pauseThings = GameObject.FindGameObjectsWithTag("pauseMenu");
        // enemies = GameObject.FindGameObjectsWithTag("enemy");
		playerMovement = player.GetComponent<playerMovement>();
	}

	public void isPaused() {
		paused = false;
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			foreach (GameObject pauseThing in pauseThings) {
				pauseThing.SetActive(false);
			}
            // foreach (GameObject enemy in enemies) {
			// 	enemy.SetActive(true);
			// }
			if (player.GetComponent<playerCombat>().isDead) {
                //player.SetActive(false);
				playerMovement.enabled = false;
				player.GetComponent<playerCombat>().enabled = false;
                player.GetComponent<playerAnimation>().enabled = false;
			} else {
                //player.SetActive(true);
				playerMovement.enabled = true;
				player.GetComponent<playerCombat>().enabled = true;
                player.GetComponent<playerAnimation>().enabled = true;
			}
		}
	}
}