using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float gameHeight;
    public float gameWidth;

    
    void Start()
    {
        gameHeight = 0;
        gameWidth = 0;
    }

    void Update()
    {
        float frustumHeight = 2.0f * Camera.main.transform.position.y
                                * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        gameHeight = frustumHeight;
        gameWidth = gameHeight * Camera.main.aspect;

      
    }
}