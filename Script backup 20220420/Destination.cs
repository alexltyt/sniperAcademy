using UnityEngine;

public class Destination : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("Enemy")) {
			Destroy (col.gameObject);
		}
	}
}

