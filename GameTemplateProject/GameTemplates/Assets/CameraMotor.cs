using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    // set position of cam in editor and will be same in code

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
	// Use this for initialization
	void Start () {
       lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        moveVector = lookAt.position + startOffset;

        // x
        moveVector.x = 0;
        // y
        // limint vertical jump
        moveVector.y = Mathf.Clamp(moveVector.y, 0, 4);
        
        transform.position = moveVector;
	}
}
