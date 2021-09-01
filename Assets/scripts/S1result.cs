//ステージ1のリザルト画面プログラムの中枢

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1result : MonoBehaviour
{
    int result;
    int HRs; //ハイスコア格納関数
    public static int HR; //ハイランク判定関数
    [SerializeField] GameObject spaceanim; //アニメーションする予定のオブジェクト指定
    public AudioClip E; //11～13行目、流す音楽の選択枠
    public AudioClip G;
    public AudioClip R;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        result = Stage1score.S1score; //ステージ1のスコアを別のスクリプトから参照
        if (HRs < Stage1score.S1score) //もしスコアが最後に取った時より高かったらハイスコアとして入れ替える
        {
            HRs = Stage1score.S1score;

        }
        //ここでスコアによってランク分けする(80%以上で良、50%以上で可、それ未満は不)
        if (HRs >= 51)
        {
            HR = 2;
        }
        else if (HRs >= 32)
        {
            HR = 1;
        }
        else
        {
            HR = 0;
        }
        audioSource = GetComponent<AudioSource>();
        //リザルトアニメーション再生
        Invoke("Result", 1f);
        Invoke("Result2", 3f);
        Invoke("ResultM", 4.5f);
        StartCoroutine("Spaceanim");

    }

    // Update is called once per frame
    void Update() //スペースキーを押したらステージセレクト画面まで戻る
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeManager.Instance.LoadScene("StageSelect", 1f);
        }
        
    }

    void Result() //点数による評価のコメント決定部分
    {
        if (result >= 51)
        {
            GameObject S1Result = (GameObject)Resources.Load("S1CommentsE");
            GameObject instance = (GameObject)Instantiate(S1Result, new Vector3(0f, 1f, 0f), Quaternion.Euler(0f,0f,180f));
            
        }
        else if (result >= 32)
        {
            GameObject S1Result = (GameObject)Resources.Load("S1CommentsG");
            GameObject instance = (GameObject)Instantiate(S1Result, new Vector3(0f, 1f, 0f), Quaternion.Euler(0f, 0f, 180f));
        }
        else
        {
            GameObject S1Result = (GameObject)Resources.Load("S1CommentsR");
            GameObject instance = (GameObject)Instantiate(S1Result, new Vector3(0f, 1f, 0f), Quaternion.Euler(0f, 0f, 180f));
        }
    }

    void Result2() //点数による評価表示部分
    {
        if (result >= 51)
        {
            GameObject S1Result2 = (GameObject)Resources.Load("ResultE");
            GameObject instance = (GameObject)Instantiate(S1Result2, new Vector3(0f, -1.2f, 0f), Quaternion.identity);

        }
        else if (result >= 32)
        {
            GameObject S1Result2 = (GameObject)Resources.Load("ResultG");
            GameObject instance = (GameObject)Instantiate(S1Result2, new Vector3(0f, -1.2f, 0f), Quaternion.identity);
        }
        else
        {
            GameObject S1Result2 = (GameObject)Resources.Load("ResultR");
            GameObject instance = (GameObject)Instantiate(S1Result2, new Vector3(0f, -1.2f, 0f), Quaternion.identity);
        }
    }

    void ResultM() //リザルト音楽決定部分
    {
        if (result >= 51)
        {
            audioSource.PlayOneShot(E);
        }
        else if (result >= 32)
        {
            audioSource.PlayOneShot(G);
        }
        else
        {
            audioSource.PlayOneShot(R);
        }
    }

    IEnumerator Spaceanim() //コルーチン関数を使ったオブジェクトの点滅処理
    {
        yield return new WaitForSeconds(6.5f);
        yield return null;
        spaceanim.SetActive(true);
        while (true)
        {
            
            yield return new WaitForSeconds(0.5f);
            yield return null;
            spaceanim.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            yield return null;
            spaceanim.SetActive(true);

        }
    }

    
}
