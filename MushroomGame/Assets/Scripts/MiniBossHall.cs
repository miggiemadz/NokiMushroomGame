using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] CinemachineVirtualCamera miniBossHallCamera;

    private void OnEnable()
    {
        CameraSwitcher.Register(mainCamera);
        CameraSwitcher.Register(miniBossHallCamera);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(mainCamera);
        CameraSwitcher.Unregister(miniBossHallCamera);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (miniBossHallCamera.Priority != 10)
            {
                CameraSwitcher.SwitchCamera(miniBossHallCamera);
            }
            else
            {
                CameraSwitcher.SwitchCamera(mainCamera);
            }
        }
    }
}
