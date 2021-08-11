using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ライブラリの追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startstage1 : MonoBehaviour
{

    // 始まった時に実行する関数
    void Start()
    {
        // ボタンが押された時、StartGame関数を実行
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // StartGame関数	
    void StartGame()
    {
        // GameSceneをロード
        SceneManager.LoadScene("stage1");
    }
}