using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossRoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainBossRoom;

    private void OnEnable()
    {
        CameraSwitcher.Register(mainBossRoom);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(mainBossRoom);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(mainBossRoom);
        }
    }
}
