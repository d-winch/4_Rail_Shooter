﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 10f;
    [Tooltip("In m")] [SerializeField] float shipXRange = 5f;
    [Tooltip("In m")] [SerializeField] float shipYRange = 3.5f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Horizontal();
        Vertical();
        Rotation();
    }

    private void Horizontal()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -shipXRange, +shipXRange);
        transform.localPosition = new Vector3(
            clampedXPos,
            transform.localPosition.y,
            transform.localPosition.z);
    }

    private void Vertical()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -shipYRange, +shipYRange);
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            clampedYPos,
            transform.localPosition.z);
    }

    private void Rotation()
    {
        float pitchDueToMovement = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;                  // Add slight pitch due to controller input while moving

        float pitch = pitchDueToMovement + pitchDueToControl;                   // x
        float yaw = transform.localPosition.x * positionYawFactor;              // y
        float roll = xThrow * controlRollFactor;                                // z

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}   
