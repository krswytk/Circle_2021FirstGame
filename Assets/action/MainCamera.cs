using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercamera : MonoBehaviour
{
    public GameObject player;

    private Transform mytrn;

    private Transform playertrn;

    private Vector3 mypos;

    private Vector3 playerpos;

    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        mytrn = this.transform;

        mypos = mytrn.position;//カメラの初期位置

        playertrn = player.transform;
        playerpos = playertrn.position;//Playerの初期位置

        //カメラとPlayerの位置関係を測定
        x = mypos.x - playerpos.x;
        y = mypos.y - playerpos.y;
        z = mypos.z - playerpos.z;
    }

    // Update is called once per frame
    void Update()
    {
        playertrn = player.transform;
        playerpos = playertrn.position;//Playerの現在値を代入

        //カメラとの位置関係を入力
        playerpos.x += x;
        playerpos.y += y;
        playerpos.z += z;

        mytrn.position = playerpos;//カメラの位置を変更
    }
}