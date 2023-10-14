using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        this.cameraTransform = Camera.main.transform;
        this.lastCameraPosition = this.cameraTransform.position;
    }

    void Update()
    {
        Vector3 deltaMovement = this.cameraTransform.position - this.lastCameraPosition;
        float parallaxEffectMultiplier = .5f;

        transform.position += deltaMovement * parallaxEffectMultiplier;
        this.lastCameraPosition = cameraTransform.position;
    }
}
