using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)//�����ɐG�ꂽ�Ƃ�
    {
        
        if (collision.gameObject.name == "goal")//�G�ꂽ�I�u�W�F�N�g�̖��O��gole�Ȃ�
        {
            Destroy(GetComponent<Rigidbody>());//Rigidbody������
        
        }
    }
}
