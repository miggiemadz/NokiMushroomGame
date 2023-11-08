using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CwCMain : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCamera;

    private void OnEnable()
    {
        CameraSwitcher.Register(mainCamera);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(mainCamera);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(mainCamera);
        }
    }
}
