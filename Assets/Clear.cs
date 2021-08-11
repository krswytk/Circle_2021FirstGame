using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public GameObject Textclear;//クリアテキストを指定する
    public GameObject Textsentaku;

    void OnCollisionEnter(Collision Player)//Playerタグを持ったオブジェクトが触れたとき
    {
        Textclear.SetActive(true);//クリアテキストを表示させる
        Textsentaku.SetActive(true);
    }
}