﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{

    public float orthographicSize = 5;
    public float aspect = 1.33333f;
    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                cam.nearClipPlane, cam.farClipPlane);
    }
}
