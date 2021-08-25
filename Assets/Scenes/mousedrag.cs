using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour
{
    private Vector2 position;//�}�E�X�ʒu���W���i�[����ϐ�

    float posx = 0, posz = 0, tmpx = 0, tmpz = 0;

    float Map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
    //Vector3 mousePos = Input.mousePosition;//�}�E�X�|�C���^�̍��W

    private void Update()
    {
        float x, z, result;
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
            //float x, z,result;

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
            Debug.Log(x);
            Debug.Log(z);

            //x = 0f;
            //z = 0f;
            x = Map(x, -150f, 150f, -45f, 45f);
            z = Map(z, -150f, 150f, -45f, 45f);

            //float Map(float x,  float 0f, float 100f, float 0f, float 45f)
            //{
            //return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
            //}
            //x = Mathf.Clamp(x,-45,45);//Mathf��if��62.63�s�ڂ��܂Ƃ߂�����
            //z = Mathf.Clamp(z,-45,45);
            posx = x + tmpx;
            posz = z + tmpz;


            if (posx > 15) { posx = 15; }
            if (posx < -15) { posx = -15; }
            if (posz > 15) { posz = 15; }
            if (posz < -15) { posz = -15; }

            //Cube�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
            //Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
            //transform.rotation = Quaternion.Euler(z, 0, x);
            //transform.Rotate(new Vector3(z, 0, x), Space.Self);//���t���[�����Ƃ�vector3�ɏ����ꂽ�����ɉ�] ��������40�t���[������]
        }
        if (Input.GetMouseButtonUp(0))
        {
            tmpx = posx;
            tmpz = posz;

        }
        transform.rotation = Quaternion.Euler(posz, 0, posx);
    }
}
