﻿using System.Collections;
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

    //ロビー画面
    [SerializeField]
    GameObject m_lobbyUI;

    //ルーム作成画面
    [SerializeField]
    GameObject m_createUI;

    //ルーム作成画面
    [SerializeField]
    GameObject m_joinUI;



    //ロビー作成ボタン
    [SerializeField]
    Button m_createWindowButton;

    //ロビー参加ボタン
    [SerializeField]
    Button m_joinWindowButton;


    //ルームテキスト
    [SerializeField]
    TextMeshProUGUI m_roomNameText;

    //パスワードテキスト
    [SerializeField]
    TextMeshProUGUI m_roomPasswordText;

    //ルーム作成ボタン
    [SerializeField]
    Button m_createRoomButton;



    // Start is called before the first frame update
    void Start()
    {

        //作成
        m_createWindowButton.onClick.AddListener(() =>
        {
            //非表示
            m_lobbyUI.gameObject.SetActive(false);
            //表示
            m_createUI.gameObject.SetActive(true);
        });

        //参加
        m_joinWindowButton.onClick.AddListener(() =>
        {
            //非表示
            m_lobbyUI.gameObject.SetActive(false);
            //表示
            m_joinUI.gameObject.SetActive(true);
        });


        m_createRoomButton.onClick.AddListener(() =>
        {
            if (NetworkUtility.Instance.CreateRoom(m_roomNameText.name, m_roomPasswordText.name))
            {
                //シーンロード
                m_sceneChanger.ChangeScene();
            }
        });

    }

}





