using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : MonoBehaviour {

	public float stepSize = 10;
	private Vector3 currentTarget;
	public float threshold = 1.0f;
	private NavMeshAgent navComponent;
	bool scriptEnabled;

	void Start () {
		navComponent = GetComponent<NavMeshAgent> ();
		currentTarget = RandomStep (transform.position);
		enableScript();
	}

	void Update () {
		if (scriptEnabled) {
			navComponent.enabled = true;
			Vector3 offset = navComponent.transform.position - currentTarget;
			offset [1] = 0f;
			if (offset.magnitude <= threshold) {
				currentTarget = RandomStep (transform.position);
			} 
			navComponent.destination = currentTarget;
		}
	}

	Vector3 RandomStep(Vector3 currentPosition){
		Vector3 step2 =  Random.insideUnitCircle.normalized;
		Vector3 step3 = new Vector3 (step2.x, 0f, step2.y);
		return currentPosition + stepSize * step3;
	}

	public void enableScript() {
		scriptEnabled = true;
	}

	public void disableScript () {
		scriptEnabled = false;
	}

}