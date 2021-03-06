using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolController : MonoBehaviour {

	public GameObject[] patrolPath;
	private GameObject currentTarget;
	private int currentIndex;
	public float threshold = 1.0f;
	private NavMeshAgent navComponent;
	bool scriptEnabled;

	void Start () {
		navComponent = GetComponent<NavMeshAgent> ();
		currentTarget = patrolPath [0];
		enableScript();
	}

	void Update () {
		if (scriptEnabled) {
			navComponent.enabled = true;
			Vector3 offset = navComponent.transform.position - currentTarget.transform.position;
			offset [1] = 0f;
			if (offset.magnitude <= threshold) {
				currentIndex = (currentIndex + 1) % patrolPath.Length;
				currentTarget = patrolPath [currentIndex];
			} 
			navComponent.destination = currentTarget.transform.position;
		}
	}

	public void enableScript() {
		scriptEnabled = true;
	}

	public void disableScript () {
		scriptEnabled = false;
	}

}