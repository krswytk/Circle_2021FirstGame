using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag: MonoBehaviour
{
    private Vector3 position;//マウス位置座標を格納する変数

    Vector3 mousePos = Input.mousePosition;//マウスポインタの座標
    void OnMouseDrag()
    {
        Vector3 pos = Input.mousePosition;//マウス位置を得る
        pos.z = 10.0f;
        Vector3 v = Camera.main.ScreenToWorldPoint(pos);

        position = Input.mousePosition;//マウス位置座標を格納

       // private var position : Vector3;
        //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);
       
        //Cubeの現在位置(マウス位置)を、pointScreenに格納
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z);

        //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Cubeの位置を、pointWorldにする
        transform.position = pointWorld;
    }

}