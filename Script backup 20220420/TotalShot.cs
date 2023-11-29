using UnityEngine.UI;
using UnityEngine;

public class TotalShot : MonoBehaviour
{
	public Text totalShot;

	void Start()
	{
		totalShot = GetComponent<Text>();
		totalShot.text = "Total Shot: " + Scope.totalShot.ToString();

	}

	void Update()
	{



	}
}
