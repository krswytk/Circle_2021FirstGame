using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject Textgameover;//�N���A�e�L�X�g���w�肷��
    public GameObject Textretry;
    public GameObject TextSentaku;

    private void OnTriggerEnter(Collider collider)
    {
        Textgameover.SetActive(true);//�N���A�e�L�X�g��\��������
        Textretry.SetActive(true);
        TextSentaku.SetActive(true);


    }
    void OnCollisionEnter(Collision Player)//Player�^�O���������I�u�W�F�N�g���G�ꂽ�Ƃ�
    {
        Textgameover.SetActive(true);//�N���A�e�L�X�g��\��������
        Textretry.SetActive(true);
        TextSentaku.SetActive(true);
    }
}