using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour {

	private GameObject gameController;
	private GameControl gameControl;
	public static int initialHealth = 100;
	public int health;
	public static int initialLives = 1;
	public int lives;
	private Vector3 initialPosition;
	private Quaternion initialRotation;
	private AudioSource audioSource;
	private GameObject rootGameObject;
	bool gameOver = false;

	void Start() {
		health = initialHealth;
		lives = initialLives;
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameController.GetComponent<GameControl> ();
		rootGameObject = transform.root.gameObject;
		initialHealth = health;
		initialPosition = rootGameObject.transform.position;
		initialRotation = rootGameObject.transform.rotation;
		audioSource = GetComponent<AudioSource>();
	}

	public void TakeRepair(int repair) {
		health += repair;
		if (gameObject.CompareTag("Player")) {
			gameControl.ReportPlayerHealth(health);
		}
		ProcessHealthChange (repair);
	}

	public void TakeDamage(int damage) {
		if (gameOver)
			return;
		health -= damage;
		if (gameObject.CompareTag("Player")) {
			gameControl.ReportPlayerHealth(health);
		}
		ProcessHealthChange (-damage);
	}

	void ProcessHealthChange(int change) {
		if (change < 0) {
			StartCoroutine (PlayHitSound ());
		}
		if (health <= 0) {
			lives--;
			if (rootGameObject.CompareTag ("Player")) {
				gameControl.ReportPlayerLives (lives);
			}
			if (lives > 0) {
				rootGameObject.transform.position = initialPosition;
				rootGameObject.transform.rotation = initialRotation;
				health = initialHealth;
			} else {
				if (gameObject.CompareTag ("Shield")) {
					Destroy (gameObject);
				} else {
					if (rootGameObject.CompareTag ("Player")) {
						gameOver = true;
						gameControl.GameOver ();
					} else {
						Destroy (rootGameObject);
					}
				}
			}
		}	
	}

	IEnumerator PlayHitSound() {
		yield return new WaitForSecondsRealtime (0.25f);
		audioSource.Play ();
	}

}
