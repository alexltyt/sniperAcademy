using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HeadshotCount : MonoBehaviour
{

	public Text headshotCount;

	public int HC;


	void Start()
	{
		headshotCount = GetComponent<Text>();
		headshotCount.text = "Head Shot: " + Scope.headshotCount.ToString();

	}

	void Update()
	{

	

	}
}