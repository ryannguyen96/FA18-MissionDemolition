﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    static public GameObject POI; // The static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;
    [Header("Set Dynamically")]

    public float camZ; // Desired Z pos of camera

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        // If there is only one line following an if, it doesn't need braces

        if (POI == null) return; // return if there is no poi

        // Get the position of poi
        Vector3 destination = POI.transform.position;

        // Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        // Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);

        // Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;

        // Set the camera to destination
        transform.position = destination;

        // Set the orthogrpahicSizeof the Camera to keep Ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }


}
