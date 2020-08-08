using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{
	public TMP_Text clock;

	float timer;
    // Start is called before the first frame update
    void Start()
    {
		timer = 0;

		clock.text = GetTimeString();   
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;

		if(timer > 30.0f)
		{
			timer -= 30.0f;
			clock.text = GetTimeString();
		}
    }

	string GetTimeString()
	{
		System.DateTime time = System.DateTime.Now;

		return time.Hour + ":" + time.Minute;
	}
}
