using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeevilsDen : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera weevilsDen;

    private void OnEnable()
    {
        CameraSwitcher.Register(weevilsDen);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(weevilsDen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraSwitcher.SwitchCamera(weevilsDen);
        }
    }
}
