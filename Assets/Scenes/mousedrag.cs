using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour
{
    private Vector2 position;//�}�E�X�ʒu���W���i�[����ϐ�

    //Vector3 mousePos = Input.mousePosition;//�}�E�X�|�C���^�̍��W

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;//�}�E�X�ʒu���W���i�[
            Debug.Log("Input.GetMouseButtonDown(0)");

        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("OnMouseDrag");
            Vector2 pos = Input.mousePosition;//�}�E�X�ʒu�𓾂�
                                              //Vector2 v = Camera.main.ScreenToWorldPoint(pos);
            float x, z;

            // private var position : Vector3;
            //Cube�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
            Vector3 objectPoint
                = Camera.main.WorldToScreenPoint(transform.position);

            //Cube�̌��݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
            /*
            Vector3 pointScreen
                = new Vector3(Input.mousePosition.x,
                              Input.mousePosition.y,
                              objectPoint.z);
            */

            //x���W��y���W�̈ʒu�̍����v��
           // x = pos.x - position.x;
            x = position.x-pos.x ;
            z = pos.y - position.y;
            /*if (x < 20) { x = 20; }
            if (x > -20) { x = -20; }
            if (z < 20) { z = 20; }
            if (z > -20) { z = -20; }*/

            //Cube�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
            //Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);

            transform.Rotate(new Vector3(z, 0, x), Space.Self);
        }


    }
}
