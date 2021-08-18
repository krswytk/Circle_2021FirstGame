using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public GameObject TextGame Over;
    public GameObject Player;
    private bool rs;

    //追加
    public GameObject Textzanki;
    public int zanki;
    private Text tzanki;
    //追加
    // Start is called before the first frame update
    void Start()
    {
        //追加
        zanki = 5;
        tzanki = Textzanki.GetComponent<Text>();
        //追加
        rs = false;
        Textzanki.SetActive(true);
        TextGameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //追加
        tzanki.text = "残機 x " + zanki.ToString();
        //追加
        if (rs == true)
        {
            //追加
            zanki = 0;
            //追加
            TextGameover.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //追加
        Failed();
        //追加
    }
    //追加
    public void Failed()
    {
        zanki--;
        if (zanki < 0)//残機がマイナスになったら
        {
            rs = true;
            Player.GetComponent<Jump>().enabled = false;//ゲームオーバーでジャンプを停止
        }
        else
        {
            Player.transform.position = new Vector3(2.79f, 19.18f, 0.0f);//初期位置に戻る
            Player.transform.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            //Playerの速度を0にする（消したらどうなるか予想しよう！）
        }
    }
    //追加

    //やっていることはCointextと殆ど同じだから分からなくなったら振り返ってみよう！！！

}

