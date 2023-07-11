using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera cam;

    private Cinemachine.Cinemachine3rdPersonFollow fpsView;
    private Cinemachine.CinemachineFramingTransposer tpsView;

    void Awake()
    {
        cam = GetComponent<Cinemachine.CinemachineVirtualCamera>();

        fpsView = new Cinemachine.Cinemachine3rdPersonFollow();
        tpsView = new Cinemachine.CinemachineFramingTransposer();

        tpsView.m_TrackedObjectOffset += Vector3.up * 3.0f;
    }

    public void ChangeViewControll()
    {  
        // FPS -> TPS
        if (cam.GetCinemachineComponent<Cinemachine.Cinemachine3rdPersonFollow>() != null)
        {
            fpsView = cam.GetCinemachineComponent<Cinemachine.Cinemachine3rdPersonFollow>();

            cam.DestroyCinemachineComponent<Cinemachine.Cinemachine3rdPersonFollow>();

            Cinemachine.CinemachineFramingTransposer camView = cam.AddCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();
            camView = tpsView;

            return;
        }

        // TPS -> FPS
        if (cam.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>() != null)
        {
            tpsView = cam.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();

            cam.DestroyCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();

            Cinemachine.Cinemachine3rdPersonFollow camView = cam.AddCinemachineComponent<Cinemachine.Cinemachine3rdPersonFollow>();
            camView = fpsView;

            return;
        }
    }
}
