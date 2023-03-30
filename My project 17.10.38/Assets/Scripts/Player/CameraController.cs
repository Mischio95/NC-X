using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
