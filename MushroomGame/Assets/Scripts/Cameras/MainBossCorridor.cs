using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossCorridor : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainBossCorridor;

    private void OnEnable()
    {
        CameraSwitcher.Register(mainBossCorridor);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(mainBossCorridor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(mainBossCorridor);
        }
    }
}
