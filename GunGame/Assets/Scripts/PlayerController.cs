using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float bulletLifeTime = 1.0f;

    [SerializeField]
    private float bulletSpeed = 10.0f;

    private CameraController cameraController;

    void Awake()
    {
        // �J�[�\����\��
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cameraController = GetComponentInChildren<CameraController>();
        cameraController.ChangeViewControll();
    }

    private void Update()
    {
        
    }

    // �E�N���b�N�i���j�Œe����
    public void OnFire()
    {
        Object obj = Instantiate(Resources.Load("Bullet"));

        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.transform.position = transform.position;
        bullet.SetParam(bulletLifeTime, bulletSpeed, cameraController.transform.forward, this);
    }

    // Space�L�[�i���j�Ŏ��_�؂�ւ�
    public void OnChangeViewController()
    {
        cameraController.ChangeViewControll();
    }
}
