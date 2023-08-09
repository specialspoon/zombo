using UnityEngine;
using System.Collections.Generic;

//example
[RequireComponent(typeof(PolyNavAgent))]
public class FollowTarget : MonoBehaviour{

	public Transform target;
	public Rigidbody2D rb;
	
	private PolyNavAgent _agent;
	private PolyNavAgent agent{
		get {return _agent != null? _agent : _agent = GetComponent<PolyNavAgent>();}
	}

	void Update() {
		if (target != null){
			agent.SetDestination( target.position );
			Vector2 lookDir = new Vector2(target.position.x, target.position.y) - rb.position;
			float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
			rb.MoveRotation(angle);
		}
	}
}