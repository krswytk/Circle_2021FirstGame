using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour
{
    private Vector2 position;//マウス位置座標を格納する変数

    float posx = 0, posz = 0, tmpx = 0, tmpz = 0;

    float Map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
    //Vector3 mousePos = Input.mousePosition;//マウスポインタの座標

    private void Update()
    {
        float x, z, result;
        if (Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;//マウス位置座標を格納
            Debug.Log("Input.GetMouseButtonDown(0)");

        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("OnMouseDrag");
            Vector2 pos = Input.mousePosition;//マウス位置を得る
                                              //Vector2 v = Camera.main.ScreenToWorldPoint(pos);
            //float x, z,result;

            // private var position : Vector3;
            //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
            Vector3 objectPoint
                = Camera.main.WorldToScreenPoint(transform.position);

            //Cubeの現在位置(マウス位置)を、pointScreenに格納
            /*
            Vector3 pointScreen
                = new Vector3(Input.mousePosition.x,
                              Input.mousePosition.y,
                              objectPoint.z);
            */

            //x座標とy座標の位置の差を計測
           // x = pos.x - position.x;
            x = position.x-pos.x ;
            z = pos.y - position.y;
            Debug.Log(x);
            Debug.Log(z);

            //x = 0f;
            //z = 0f;
            x = Map(x, -150f, 150f, -45f, 45f);
            z = Map(z, -150f, 150f, -45f, 45f);

            //float Map(float x,  float 0f, float 100f, float 0f, float 45f)
            //{
            //return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
            //}
            //x = Mathf.Clamp(x,-45,45);//Mathfはifと62.63行目をまとめた処理
            //z = Mathf.Clamp(z,-45,45);
            posx = x + tmpx;
            posz = z + tmpz;


            if (posx > 15) { posx = 15; }
            if (posx < -15) { posx = -15; }
            if (posz > 15) { posz = 15; }
            if (posz < -15) { posz = -15; }

            //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
            //Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
            //transform.rotation = Quaternion.Euler(z, 0, x);
            //transform.Rotate(new Vector3(z, 0, x), Space.Self);//毎フレームごとにvector3に書かれた数字に回転 ここだと40フレームずつ回転
        }
        if (Input.GetMouseButtonUp(0))
        {
            tmpx = posx;
            tmpz = posz;

        }
        transform.rotation = Quaternion.Euler(posz, 0, posx);
    }
}
