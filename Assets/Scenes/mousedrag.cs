using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag: MonoBehaviour
{
    private Vector3 position;//�}�E�X�ʒu���W���i�[����ϐ�

    Vector3 mousePos = Input.mousePosition;//�}�E�X�|�C���^�̍��W
    void OnMouseDrag()
    {
        Vector3 pos = Input.mousePosition;//�}�E�X�ʒu�𓾂�
        pos.z = 10.0f;
        Vector3 v = Camera.main.ScreenToWorldPoint(pos);

        position = Input.mousePosition;//�}�E�X�ʒu���W���i�[

       // private var position : Vector3;
        //Cube�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);
       
        //Cube�̌��݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z);

        //Cube�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Cube�̈ʒu���ApointWorld�ɂ���
        transform.position = pointWorld;
    }

}