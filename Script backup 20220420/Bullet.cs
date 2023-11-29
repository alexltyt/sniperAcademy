using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 2;
	float damage;
	Vector3 mPrevPos;

	void OnTriggerEnter(Collider col)
	{
		Debug.Log(col.tag);
		if (col.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Hello");
			col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}
		
	}
		
	void Update()
	{
	
		//	mPrevPos = transform.position;
		//	transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
		//	RaycastHit[] hits = Physics.RaycastAll(new Ray(mPrevPos, (transform.position - mPrevPos).normalized), (transform.position - mPrevPos).magnitude);
		//	for (int i = 0; i < hits.Length; i++)
		//	{
		//		Debug.Log(hits[i].collider.gameObject.name);
		//	}
		//	Debug.DrawLine(transform.position, mPrevPos);
		//}

		//void SetDamage (float power) {
		//	damage = power;
	}
}


