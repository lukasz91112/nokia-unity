using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	public float mouseSensivity;
	private float angle;

	void Start()
	{
		angle = 0.0f;
	}

	void Update () 
	{
		Rotate();
	}

	private void Rotate()
	{
        float mouseVertical = Input.GetAxis("Mouse Y");
        Vector3 cameraRotation = transform.rotation.eulerAngles;
		float inputVerticalRotation = mouseVertical * mouseSensivity;
		angle += inputVerticalRotation;
		float updatedVerticalRotation = cameraRotation.x + inputVerticalRotation;
		if(angle >= 90f)
		{
			angle = 90f;
			updatedVerticalRotation = 90f;
		}
		else if (angle <= -90f)
		{
			angle = -90f;
			updatedVerticalRotation = 270f;
		}

		cameraRotation.x = updatedVerticalRotation;

        // To avoid camera upside-down bug
        cameraRotation.z = 0;

        transform.rotation = Quaternion.Euler(cameraRotation);
	}
}
