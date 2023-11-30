using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class NewCameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] CWCCameras;
    [SerializeField] private CapsuleCollider2D[] cameraChangers;

    private bool cameraChange;

    private void cameraChangeCollision()
    {
        foreach (CapsuleCollider2D c in cameraChangers)
        {
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("trigger");
            cameraChange = true;
        }
    }
}
