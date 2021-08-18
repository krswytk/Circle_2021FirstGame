using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour
{
    private Vector2 position;//マウス位置座標を格納する変数

    //Vector3 mousePos = Input.mousePosition;//マウスポインタの座標

    private void Update()
    {
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
            float x, z;

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
            /*if (x < 20) { x = 20; }
            if (x > -20) { x = -20; }
            if (z < 20) { z = 20; }
            if (z > -20) { z = -20; }*/

            //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
            //Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);

            transform.Rotate(new Vector3(z, 0, x), Space.Self);
        }


    }
}
