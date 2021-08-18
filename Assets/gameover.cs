using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject Textgameover;//クリアテキストを指定する
    public GameObject Textretry;
    public GameObject TextSentaku;

    private void OnTriggerEnter(Collider collider)
    {
        Textgameover.SetActive(true);//クリアテキストを表示させる
        Textretry.SetActive(true);
        TextSentaku.SetActive(true);


    }
    void OnCollisionEnter(Collision Player)//Playerタグを持ったオブジェクトが触れたとき
    {
        Textgameover.SetActive(true);//クリアテキストを表示させる
        Textretry.SetActive(true);
        TextSentaku.SetActive(true);
    }
}