using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    private int point;
    private string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    private int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[5];
    [SerializeField, Header("NewRecordテキストオブジェクト")]
    GameObject NewRecord_Obj;
    [SerializeField, Header("NewRecordテキスト")]
    Text NewRecord;
    Score score;
    int rank;
    // Use this for initialization
    void Start()
    {
        score = GetComponent<Score>();
        point = Score.PlayerScore_int;
        rank = 6;
        GetRanking();
        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
    }
    private void Update()
    {
        Debug.Log(rank);
        if (rank < 6)
        {
            rankingText[rank].color = Clear_GameOver.GetAlphaColor(rankingText[rank].color);
        }
        if (rank == 0)
        {
            NewRecord.color = Clear_GameOver.GetAlphaColor(NewRecord.color);
            NewRecord_Obj.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FadeManager.Instance.LoadScene("stage_select", 2.0f);
        }
    }
    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
                rank = i;//ランキングを保存
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}

