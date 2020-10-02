using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHarmfulController : MonoBehaviour {

	public int healthChange = 100;
	private AudioSource audioSource;
	public GameObject gameController;

	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider collider) {
		collider.gameObject.GetComponent<CharacterHealth> ().TakeDamage(healthChange);
		if (collider.gameObject.CompareTag("Player")
			|| collider.gameObject.CompareTag("NPC")) {
			audioSource.Play ();
			StartCoroutine (Die ());
		}
	}

	IEnumerator Die() {
		yield return new WaitForSecondsRealtime (1.25f);
		Destroy (this.gameObject);
	}
}
