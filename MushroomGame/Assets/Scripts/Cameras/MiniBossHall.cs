using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera miniBossHallCamera;

    private void OnEnable()
    {
        CameraSwitcher.Register(miniBossHallCamera);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(miniBossHallCamera);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("miniBoss priority = " + miniBossHallCamera.Priority);

        if (collision.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(miniBossHallCamera);
        }

    }
}
