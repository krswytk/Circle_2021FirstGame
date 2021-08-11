using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)//何かに触れたとき
    {
        
        if (collision.gameObject.name == "goal")//触れたオブジェクトの名前がgoleなら
        {
            Destroy(GetComponent<Rigidbody>());//Rigidbodyを消す
        
        }
    }
}
