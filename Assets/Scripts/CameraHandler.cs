using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour {

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float orthographicSize;
    private float targetOrthographicSize;

    private void Update() {
        HandleZoom();
    }

    private void HandleZoom() { 
     float zoomAmount = 2f;
    targetOrthographicSize += -Input.mouseScrollDelta.y* zoomAmount;

    float minOrthographicSize = 7f;
    float maxOrthographicSize = 15f;

    targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

    orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime* zoomAmount);

     cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
