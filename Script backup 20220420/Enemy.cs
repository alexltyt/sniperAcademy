using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	NavMeshAgent NM;
	Transform dest;

	void Start () {
		dest = GameObject.Find ("EndPoint").transform;
		NM = GetComponent<NavMeshAgent> ();
		NM.SetDestination (dest.position);
	}
}


