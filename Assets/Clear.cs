using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public GameObject Textclear;//�N���A�e�L�X�g���w�肷��
    public GameObject Textsentaku;

    void OnCollisionEnter(Collision Player)//Player�^�O���������I�u�W�F�N�g���G�ꂽ�Ƃ�
    {
        Textclear.SetActive(true);//�N���A�e�L�X�g��\��������
        Textsentaku.SetActive(true);
    }
}