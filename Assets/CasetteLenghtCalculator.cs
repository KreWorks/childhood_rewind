using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasetteLenghtCalculator : MonoBehaviour
{
	/*
	 60 min - 90 m
	 90 mint - 135 m
	 120 min - 180 m
	*/

	public GameObject pen;

	float fullRotation;

    // Start is called before the first frame update
    void Start()
    {
		fullRotation = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
		//Rotate the pen's right position with the rotation of the casette
		Vector3 rot = this.transform.rotation * pen.transform.right;
		//Projects the rotated vector to a plane which normal is the pen up
		Vector3 rotProj = Vector3.ProjectOnPlane(rot, pen.transform.up);
		//Calculate the angle of the casette rotation projected to the plane perpendicular to the pen
		float angle = Vector3.Angle(pen.transform.right, rotProj);

		fullRotation += angle;
		Debug.Log(fullRotation);
	}
}
