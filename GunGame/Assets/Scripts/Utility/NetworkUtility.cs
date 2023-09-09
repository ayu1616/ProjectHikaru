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
        [SerializeField] private GameObject m_can;
        [SerializeField] private GameObject m_playerObject;
        
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
            bool isJoined = PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
            if (isJoined)
            {
                //座標ランダム
                var position = m_playerObject.transform.position;
                position.x = UnityEngine.Random.Range(-10.0f, 10.0f);
                position.z = UnityEngine.Random.Range(-10.0f, 10.0f);
                
                //缶を生成して親設定
                var canInstance = Instantiate(m_can, position, Quaternion.identity);
                m_playerObject.transform.parent = canInstance.transform;
                
                //プレイヤー生成
                PhotonNetwork.Instantiate(m_playerObject.name, position, Quaternion.identity);
            }
        }
        
    }
    
}