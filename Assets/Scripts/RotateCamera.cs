using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

    public float rotateSpeed = 1.0f;

	// Update is called once per frame
	void FixedUpdate () {
        transform.transform.Rotate(transform.position, rotateSpeed * Time.deltaTime);
	}
}
