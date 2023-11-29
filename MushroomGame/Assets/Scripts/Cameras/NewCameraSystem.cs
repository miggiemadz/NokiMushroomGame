using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class NewCameraSystem : MonoBehaviour
{
    [SerializeField] List<CinemachineVirtualCamera> CWCCameras = new List<CinemachineVirtualCamera>();
    [SerializeField] List<CapsuleCollider2D> CWCCameraSwitchers = new List<CapsuleCollider2D>();
    
}
