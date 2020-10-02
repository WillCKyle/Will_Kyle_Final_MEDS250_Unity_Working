using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHelpfulController : MonoBehaviour {

	public int healthChange = 20;
	private AudioSource audioSource;
	private GameObject gameController;
	private GameControl gameControl;

	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameController.GetComponent<GameControl> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player")) {
			collider.gameObject.GetComponent<CharacterHealth> ().TakeRepair(healthChange);
			gameControl.DecrementPickUpCount ();
			audioSource.Play ();
			StartCoroutine (Die ());
		}
	}

	IEnumerator Die() {
		yield return new WaitForSecondsRealtime (1.25f);
		Destroy (this.gameObject);
	}
}
