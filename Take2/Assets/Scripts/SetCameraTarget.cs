using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetCameraTarget : MonoBehaviour
{
    private string playerTag = "Player";
    public CinemachineVirtualCamera VirtualCam;

    private void Awake()
    {
        // TODO : When implementing multiplayer, switch to .FindGameObjectsWithTag and check if is local
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        VirtualCam.Follow = player.transform;
    }
}
