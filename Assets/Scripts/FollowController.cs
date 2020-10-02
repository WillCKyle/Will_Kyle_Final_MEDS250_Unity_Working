using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowController : MonoBehaviour {

	private GameObject target;
	public float threshold = 5.0f;
	public float fudge = 0.5f;
	public float maxSeparation = 100f;
	public bool lineOfSight;
	private NavMeshAgent navComponent;
	private bool scriptEnabled;
	private PatrolController patrolController;

	void Start () {
		target =  GameObject.FindGameObjectWithTag ("Player");
		navComponent = GetComponent<NavMeshAgent> ();
		patrolController = GetComponent<PatrolController> ();
		enableScript();
	}

	void Update () {
		if (scriptEnabled) {
			Vector3 offset = navComponent.transform.position - target.transform.position;
			offset [1] = 0f;
			float separation = offset.magnitude;
			bool inSight = InSight ();
            Debug.Log("In Sight ="+inSight);

			if (separation <= threshold) {
				navComponent.enabled = false;
			} else if ((separation > maxSeparation) || (lineOfSight && !inSight)) {
				if (patrolController != null) {
					patrolController.enableScript ();
					navComponent.enabled = true;
				}
			} else if (separation > threshold + fudge && separation <= maxSeparation && (!lineOfSight || inSight)) {
				navComponent.enabled = true;
				navComponent.destination = target.transform.position;
				if (patrolController != null) {
					patrolController.disableScript();
				}
			}

		}
	}

	private bool InSight() {
		Vector3 origin = transform.position;
		Vector3 direction = (target.transform.position - origin);
		direction = direction.normalized;
		RaycastHit shootHit;
		if (Physics.Raycast (origin, direction, out shootHit, Mathf.Infinity)) {
			if (shootHit.collider.gameObject==target) {
				return true;
			} else { 
				return false;
			}
		} else {
			return false;
		}

	}

	public void enableScript() {
		scriptEnabled = true;
	}

	public void disableScript () {
		scriptEnabled = false;
	}

}