using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    private int point;
    private string[] ranking = { "�����L���O1��", "�����L���O2��", "�����L���O3��", "�����L���O4��", "�����L���O5��" };
    private int[] rankingValue = new int[5];

    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[5];
    [SerializeField, Header("NewRecord�e�L�X�g�I�u�W�F�N�g")]
    GameObject NewRecord_Obj;
    [SerializeField, Header("NewRecord�e�L�X�g")]
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
    /// �����L���O�Ăяo��
    /// </summary>
    void GetRanking()
    {
        //�����L���O�Ăяo��
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(int _value)
    {
        //�������ݗp
        for (int i = 0; i < ranking.Length; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
                rank = i;//�����L���O��ۑ�
            }
        }

        //����ւ����l��ۑ�
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}

