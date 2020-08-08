using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
	//https://www.youtube.com/watch?v=ixM2W2tPn6c
	public float mouseSensitivity;
	public float speed;

	Rigidbody rb;

	Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		float mouseXValue = Input.GetAxis("Mouse X");
		float mouseYValue = Input.GetAxis("Mouse Y");


		if (Input.GetMouseButton(1))
		{
			movement = new Vector3(mouseXValue, 0, mouseYValue) * mouseSensitivity;
		}
			
		
    }

	void FixedUpdate()
	{
		if (movement != new Vector3(0, 0, 0))
		{
			rb.MovePosition(this.transform.position + movement * speed * Time.deltaTime);
		}
	}
}
