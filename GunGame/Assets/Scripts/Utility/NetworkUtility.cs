using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Utility
{

    public class NetworkUtility : SingletonMonoBehaviour<NetworkUtility>
    {        
        //初期化変数
        private bool m_isInitialize = false;
        //ルーム作成
        private bool m_isCreateRoom = false;

        public bool TryInitialize()
        {
            try
            {
                if (!m_isInitialize)
                {
                    m_isInitialize = PhotonNetwork.ConnectUsingSettings();
                }
                return m_isInitialize;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }

        // Start is called before the first frame update
        void Start()
        {
            TryInitialize();
        }



        public bool CreateRoom(string roomName, string password = null)
        {
            //ルーム作成済み
            if (m_isCreateRoom) return true;
            //初期化失敗
            if (!TryInitialize()) return false;

            string key = roomName + "_" + password;

            //ルーム作成
            bool isJoined = PhotonNetwork.CreateRoom(key, new RoomOptions(), TypedLobby.Default);
            if (isJoined)
            {
                Debug.Log("ルーム作成しました。");
                m_isCreateRoom = true;
                return true;
            }

            Debug.LogError("ルーム作成に失敗しました。");
            return false;
        }



        //マスターサーバーへの接続が成功した時に呼ばれる
        //TODO 本実装では無し
        private void OnConnectedToServer()
        {
            Debug.Log("サーバーに接続された");
        }
        
    }
    
}