using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Goal : MonoBehaviour
{
    //Inspector�ŃL�����N�^�[�ƃS�[���I�u�W�F�N�g�̎w����o����l�ɂ��܂��B
    public GameObject chara;
    public GameObject gameclea;


    private void OnTriggerEnter(Collider other)
    {
        //�����S�[���I�u�W�F�N�g�̃R���C�_�[�ɐڐG�������̏����B
        if (other.name == chara.name)
        {
            //�Q�[���N���A�e�L�X�g��\�������ăL�����N�^�[���\���ɂ��܂��B
            gameclea.GetComponent<Text>();
            gameclea.SetActive(true);
            

        }
    }

}