using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���C�u�����̒ǉ�
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startstage1 : MonoBehaviour
{

    // �n�܂������Ɏ��s����֐�
    void Start()
    {
        // �{�^���������ꂽ���AStartGame�֐������s
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // StartGame�֐�	
    void StartGame()
    {
        // GameScene�����[�h
        SceneManager.LoadScene("stage1");
    }
}