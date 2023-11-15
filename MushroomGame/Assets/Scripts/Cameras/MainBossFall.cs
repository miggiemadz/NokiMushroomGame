using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossFall : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainBossFall;

    private void OnEnable()
    {
        CameraSwitcher.Register(mainBossFall);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(mainBossFall);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(mainBossFall);
        }
    }
}
