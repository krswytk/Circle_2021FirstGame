using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    //重力の加速度の値
    const float Gravity = 9.8f;
    //重力がどの程度適用されるか
    public float scale = 1.0f;

    void Update()
    {
       　//重力のベクトルを初期化します。
        Vector3 vector = new Vector3();
        //カーソルキーの入力を検知して位置を設定
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");
        //高さ方向の判定はキーのzとします。
        if (Input.GetKey("z"))
        {
            //高さ方向の入力を取得
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }
        //重力を入力方向に合わせて変化させる。
        Physics.gravity = Gravity * vector.normalized * scale;
    }
}