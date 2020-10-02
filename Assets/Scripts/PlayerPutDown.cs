using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPutDown : MonoBehaviour {

	private GameObject gameController;
	private GameControl gameControl;
	public GameObject spawnPoint;
	public GameObject prototype;
	public int dropSupply = 10;

	void Start() {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameController.GetComponent<GameControl> ();
	}

	void Update () {
		if (dropSupply > 0 && Input.GetKeyDown(KeyCode.F)) {
			GameObject pd = Instantiate (prototype, spawnPoint.transform.position, Quaternion.identity);
			pd.SetActive (true);
			dropSupply--;
			gameControl.ReportPutDownCount(dropSupply);
		}
	}
}
