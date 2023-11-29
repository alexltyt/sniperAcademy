using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

	Text text;
	public static float time = 10;
	public UnityEvent timesupEvent;
	bool Timesup = false;
	public static float timeleft;
	public GameObject Panel;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
	{
		if (time > 0)
        {
			time -= Time.deltaTime;
			timeleft = (int)time;
		}
			
		else if (!Timesup)
		{
			Time.timeScale = 0;
			time = 0;
			timesupEvent.Invoke();
			Timesup = true;

		}
		
		if (text) text.text = Mathf.Ceil(time).ToString("00");
		


	}
}