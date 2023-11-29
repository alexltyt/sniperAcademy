using UnityEngine.UI;
using UnityEngine;

public class BulletLeft: MonoBehaviour
{
	public Text bulletLeft;
	public int bulletLeftNum;

	void Start()
	{
		bulletLeft = GetComponent<Text>();
		bulletLeftNum = Scope.AmmoNum - Scope.totalShot;
		bulletLeft.text = "Bullet Left: " + bulletLeftNum.ToString();
	}

	void Update()
	{



	}
}
