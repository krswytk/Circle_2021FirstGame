using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    //�d�͂̉����x�̒l
    const float Gravity = 9.8f;
    //�d�͂��ǂ̒��x�K�p����邩
    public float scale = 1.0f;

    void Update()
    {
       �@//�d�͂̃x�N�g�������������܂��B
        Vector3 vector = new Vector3();
        //�J�[�\���L�[�̓��͂����m���Ĉʒu��ݒ�
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");
        //���������̔���̓L�[��z�Ƃ��܂��B
        if (Input.GetKey("z"))
        {
            //���������̓��͂��擾
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }
        //�d�͂���͕����ɍ��킹�ĕω�������B
        Physics.gravity = Gravity * vector.normalized * scale;
    }
}