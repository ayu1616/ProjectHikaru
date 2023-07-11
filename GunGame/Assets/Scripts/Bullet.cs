using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const int possessionLayer = 9;  // Possession

    private float speed;

    private Vector3 direction;

    private float lifeTime;

    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        lifeTime -= Time.deltaTime;

        if (lifeTime < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetParam(float lifeT, float sp, Vector3 dir, PlayerController plController)
    {
        lifeTime = lifeT;
        speed = sp;
        direction = dir;

        direction.Normalize();

        playerController = plController;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 憑依してるオブジェクトとの判定は無視する
        if (collision.gameObject.name == playerController.transform.parent.name) return;

        // 憑依してるオブジェクト以外と当たったら弾は消える
        Destroy(gameObject);

        // 憑依できないオブジェクトとの判定も無視する
        if (!collision.gameObject.layer.Equals(possessionLayer))
        {
            return;
        }

        // プレイヤーの魂移動(憑依)
        playerController.transform.parent = collision.transform;
        playerController.transform.localPosition = collision.gameObject.GetComponent<PossessionObjectBase>().GetPlayerLocalPoition();

        //// 憑依してるオブジェクト以外と当たったら弾は消える
        //Destroy(gameObject);
    }
}
