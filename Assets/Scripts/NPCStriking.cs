using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStriking : MonoBehaviour {

	private GameObject target;
	public int damagePerStrike = 10;
	public float timeBetweenStrikes = 2f;
	public float range = 3f;
	CharacterHealth characterHealth;
	float timer = 0f;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		characterHealth = target.GetComponent<CharacterHealth> ();
	}
	

	void Update () {
		target = GameObject.FindGameObjectWithTag ("Player");
		timer += Time.deltaTime;
		Vector3 displacement = target.transform.position - transform.position;
		displacement [1] = 0f;
		float separation = displacement.magnitude;
		if (separation <= range && timer >= timeBetweenStrikes) {
			characterHealth.TakeDamage (damagePerStrike);
			timer = 0f;
		}

	}
}
