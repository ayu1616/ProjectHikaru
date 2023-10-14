using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

public class LobbyProc : MonoBehaviour
{
    [SerializeField]
    SceneChanger m_sceneChanger;

    //���r�[���
    [SerializeField]
    GameObject m_lobbyUI;

    //���[���쐬���
    [SerializeField]
    GameObject m_createUI;

    //���[���쐬���
    [SerializeField]
    GameObject m_joinUI;



    //���r�[�쐬�{�^��
    [SerializeField]
    Button m_createWindowButton;

    //���r�[�Q���{�^��
    [SerializeField]
    Button m_joinWindowButton;


    //���[���e�L�X�g
    [SerializeField]
    TextMeshProUGUI m_roomNameText;

    //�p�X���[�h�e�L�X�g
    [SerializeField]
    TextMeshProUGUI m_roomPasswordText;

    //���[���쐬�{�^��
    [SerializeField]
    Button m_createRoomButton;



    // Start is called before the first frame update
    void Start()
    {

        //�쐬
        m_createWindowButton.onClick.AddListener(() =>
        {
            //��\��
            m_lobbyUI.gameObject.SetActive(false);
            //�\��
            m_createUI.gameObject.SetActive(true);
        });

        //�Q��
        m_joinWindowButton.onClick.AddListener(() =>
        {
            //��\��
            m_lobbyUI.gameObject.SetActive(false);
            //�\��
            m_joinUI.gameObject.SetActive(true);
        });


        m_createRoomButton.onClick.AddListener(() =>
        {
            if (NetworkUtility.Instance.CreateRoom(m_roomNameText.name, m_roomPasswordText.name))
            {
                //�V�[�����[�h
                m_sceneChanger.ChangeScene();
            }
        });

    }

}





