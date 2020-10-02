using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public Text livesText;
	public Text healthText;
	public Text ammoText;
	public Text pickUpCountText;
	public Text putDownCountText;
	private int pickUpCount;

	void Start() {
		pickUpCount = GameObject.FindGameObjectsWithTag ("PickUpHelpful").Length;
		DisplayPickUpCount (pickUpCount);
		DisplayHealth (CharacterHealth.initialHealth);
		DisplayLives (CharacterHealth.initialLives);
	}

	private void DisplayPickUpCount(int pickUpCount) {
		if (pickUpCountText != null) {
			pickUpCountText.text = "PickUpCount: " + pickUpCount;
		}
	}

	private void DisplayHealth(int health) {
		if (healthText != null) {
			healthText.text = "Health: " + health;
		}		
	}

	private void DisplayLives(int lives) {
		if (livesText != null) {
			livesText.text = "Lives: " + lives;
		}		
	}

	public void ReportPlayerLives(int lives) {
		DisplayLives (lives);
	}

	public void ReportPlayerHealth(int health) {
		DisplayHealth (health);
	}

	public void ReportPlayerAmmo(int ammo) {
		DisplayAmmo (ammo);
	}

	private void DisplayAmmo(int ammo) {
		if (ammoText != null) {
			ammoText.text = "Ammo: " + ammo;
		}		
	}

	public void DecrementPickUpCount() {
		pickUpCount--;
		DisplayPickUpCount (pickUpCount);
		if (pickUpCount <=0) {
			YouWin ();
		}
	}

	public void ReportPutDownCount(int pdCount) {
		DisplayPutDownCount (pdCount);
	}

	private void DisplayPutDownCount(int putDownCount) {
		if (putDownCountText != null) {
			putDownCountText.text = "PutDownCount: " + putDownCount;
		}
	}

	public void YouWin() {
		StartCoroutine ("LoadYouWinScene");
	}

	IEnumerator LoadYouWinScene() {
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene ("YouWin");
	}

	public void GameOver() {
		StartCoroutine ("LoadGameOverScene");
	}

	IEnumerator LoadGameOverScene() {
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene ("GameOver");
	}
}
