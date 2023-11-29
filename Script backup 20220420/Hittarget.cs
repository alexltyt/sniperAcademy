using UnityEngine.UI;
using UnityEngine;

public class Hittarget : MonoBehaviour
{
	public Text hitTarget;

	void Start()
	{
		hitTarget = GetComponent<Text>();
		hitTarget.text = "Hit Target: " + Scope.hitTarget.ToString();

	}

	void Update()
	{



	}

}
