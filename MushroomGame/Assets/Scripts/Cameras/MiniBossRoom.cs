using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossRoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera miniBossRoom;

    private void OnEnable()
    {
        CameraSwitcher.Register(miniBossRoom);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(miniBossRoom);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(miniBossRoom);
        }
    }
}
