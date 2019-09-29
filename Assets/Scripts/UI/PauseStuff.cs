using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseStuff : MonoBehaviour {

	public bool paused = false;
	GameObject[] pauseThings;
    // GameObject[] enemies;
	GameObject resumeButton;
	GameObject player;
	playerMovement playerMovement;

	void Start()
	{
		Time.timeScale = 1f;
		player = GameObject.FindWithTag ("Player");
		resumeButton = GameObject.Find ("resumeButton");
		playerMovement = player.GetComponent<playerMovement>();
        //	GameObject.Find("Main Camera").AudioListener.volume = GameObject.Find("volumeSlider").GetComponent<Slider>().value;
		pauseThings = GameObject.FindGameObjectsWithTag("pauseMenu");
        // enemies = GameObject.FindGameObjectsWithTag("enemy");
		
        foreach (GameObject pauseThing in pauseThings) {
			pauseThing.SetActive(false);
		}
	}

	void Update()
	{
		if (Input.GetButtonDown ("Cancel")) {
			resumeButton.GetComponent<ResumeStuff>().paused = togglePause ();
		}

		paused = resumeButton.GetComponent<ResumeStuff> ().paused;
	}


	bool togglePause()
	{
		if(paused)
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
			return(false);
		}
		else
		{
			foreach (GameObject pauseThing in pauseThings) {
				pauseThing.SetActive(true);
			}
            // foreach (GameObject enemy in enemies) {
			// 	enemy.SetActive(false);
			// }
            //player.SetActive(false);
			playerMovement.enabled = false;
			player.GetComponent<playerCombat>().enabled = false;
            player.GetComponent<playerAnimation>().enabled = false;
			Time.timeScale = 0f;
			return(true);
		}
	}
}