using UnityEngine.UI;
using UnityEngine;

public class Accuracy : MonoBehaviour
{
	public float accuracy;
	public int accuracyint;
	public Text accuracyText;

	void Start()
	{
		accuracy = Scope.hitTarget / Scope.totalShot *100;
		accuracyint = (int)(accuracy);
		accuracyText = GetComponent<Text>();
		accuracyText.text = "Accuracy: " + accuracyint.ToString()+"%";

	}

	void Update()
	{



	}
}
