using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject m_playerObject;

    [SerializeField]
    private GameObject m_can;



    // Start is called before the first frame update
    void Start()
    {

        
    }



    public void CreatePlayer()
    {
        if (!NetworkUtility.Instance.TryInitialize()) return;

        //座標ランダム
        var position = m_playerObject.transform.position;
        position.x = UnityEngine.Random.Range(-10.0f, 10.0f);
        position.z = UnityEngine.Random.Range(-10.0f, 10.0f);

        //プレイヤー生成
        var playerInstance = PhotonNetwork.Instantiate(m_playerObject.name, position, Quaternion.identity);

        //缶を生成して親設定
        var canInstance = PhotonNetwork.Instantiate(m_can.name, position, Quaternion.identity);
        playerInstance.transform.parent = canInstance.transform;
    }

}
