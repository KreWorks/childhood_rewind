using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CasetteLenghtCalculator : MonoBehaviour
{
	/*
	 60 min - 90 m
	 90 mint - 135 m
	 120 min - 180 m
	*/
	public int roundNeeded;

	public GameObject pen;
	public TMP_Text rotationText;

	float fullRotation;

	float lastAngle;
	int actualRound;


    // Start is called before the first frame update
    void Start()
    {
		fullRotation = 0.0f;
		lastAngle = this.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
		/*
		//Rotate the pen's right position with the rotation of the casette
		Vector3 rot = this.transform.rotation * pen.transform.right;
		//Projects the rotated vector to a plane which normal is the pen up
		Vector3 rotProj = Vector3.ProjectOnPlane(this.transform.rotation.eulerAngles, pen.transform.up);
		//Calculate the angle of the casette rotation projected to the plane perpendicular to the pen
		float angle = Vector3.Angle(pen.transform.right, rotProj);
		*/

		float angle = GetRotationAngle();

		fullRotation += angle;

		rotationText.text = Mathf.FloorToInt(fullRotation).ToString();
		lastAngle = this.transform.rotation.eulerAngles.y;

		//Debug.Log(this.transform.rotation.eulerAngles.y + " " + angle + " " + fullRotation);
	}

	float GetRotationAngle()
	{
		float angle = lastAngle - this.transform.rotation.eulerAngles.y; 

		if(angle > 300)
		{
			angle -= 360;
		}
		else if (angle < -300)
		{
			angle += 360;
		}

		return angle;
	}


}
