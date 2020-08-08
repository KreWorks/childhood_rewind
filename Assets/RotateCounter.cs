using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateCounter : MonoBehaviour
{
	public int roundNeeded;

	public Slider leftSide;
	public Slider rightSide;

	public GameObject pen;

	public TMP_Text speedText;

	int startRotationCount;
	int rotationCounter;

	float fullRotationDegree;

	float lastAngle;
	float rotationTime;

	Vector3 startPosition;
	Quaternion startRotation;
	
	// Start is called before the first frame update
	void Start()
    {
		//Debug.Log(SystemInfo.deviceUniqueIdentifier);
		ResetStartCondition();
	}

    // Update is called once per frame
    void Update()
    {
		/*
		//Rotate the pen's right position with the rotation of the casette
		Vector3 rot = this.transform.rotation * -pen.transform.right;
		//Projects the rotated vector to a plane which normal is the pen up
		Vector3 rotProj = Vector3.ProjectOnPlane(this.transform.rotation.eulerAngles, pen.transform.forward);
		//Calculate the angle of the casette rotation projected to the plane perpendicular to the pen
		float angle = Vector3.Angle(pen.transform.right, rotProj);
		Debug.Log(rot + " " + rotProj + " " + angle + " " + fullRotationDegree);*/
		if (Input.GetMouseButton(1))
		{
			rotationTime += Time.deltaTime;
		}

		float angle = GetRotationAngle();
	
		fullRotationDegree += angle;
		lastAngle = this.transform.rotation.eulerAngles.y;

		rotationCounter = startRotationCount + Mathf.FloorToInt(fullRotationDegree / 360);

		ChangeSliders();


		if(rotationCounter == 0 || rotationCounter == roundNeeded)
		{
			MenuPanelManager menuPanelManager = MenuPanelManager.GetInstance();
			menuPanelManager.SwitchMenuPanel(MenuPanelType.EndGameWinMenu);

			speedText.text = "You spin the casette " + GetRotationSpeed() + " degree/sec. You are awesome. ";
		}	
	}

	public void ResetStartCondition()
	{
		startPosition = this.transform.position;
		startRotation = this.transform.rotation;

		startRotationCount = (int)Random.Range(0.2f * roundNeeded, 0.8f*roundNeeded);
		rotationCounter = startRotationCount;

		ChangeSliders();

		fullRotationDegree = 0.0f;
		rotationTime = 0.0f;
		lastAngle = this.transform.rotation.eulerAngles.y;
	}


	float GetRotationAngle()
	{
		float angle = lastAngle - this.transform.rotation.eulerAngles.y;

		if (angle > 300)
		{
			angle -= 360;
		}
		else if (angle < -300)
		{
			angle += 360;
		}

		return angle;
	}

	void ChangeSliders()
	{
		leftSide.value = (float)rotationCounter / roundNeeded;
		rightSide.value = 1.0f - leftSide.value;
	}

	public float GetRotationSpeed()
	{
		return Mathf.FloorToInt(fullRotationDegree / rotationTime);
	}
}
