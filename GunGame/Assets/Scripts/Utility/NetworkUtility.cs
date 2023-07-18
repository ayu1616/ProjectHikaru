using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Utility
{

    public class NetworkUtility : MonoBehaviour
    {
        //初期化変数
        private bool m_isInitialize = false;

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


        //マスターサーバーへの接続が成功した時に呼ばれる
        //TODO 本実装では無し
        private void OnConnectedToServer()
        {
            PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
        }
        
    }
    
}