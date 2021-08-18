using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 force;

    private int Jp;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        force = new Vector3(0.0f, 0.0f, 0.0f);

        Jp = 0;
    }

    // Update is called once per frame
    void Update()
    {

        force = new Vector3(0f, 0f, 0f);

        if (Jp < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                force.y += 300.0f;
                Jp++;
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            force.x += 5.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force.x -= 5.0f;
        }

        rb.AddForce(force);

        /* if (Input.GetKey(KeyCode.Space))
         {
             this.gameObject.transform.Translate(0f, 0.5f, 0f);
         }
         if (Input.GetKey(KeyCode.D))
         {
             this.gameObject.transform.Translate(0.1f, 0f, 0f);
         }
         if (Input.GetKey(KeyCode.A))
         {
             this.gameObject.transform.Translate(-0.1f, 0f, 0f);
         }*/
    }
    private void OnCollisionEnter(Collision collision)//�����ɐG�ꂽ�Ƃ�
    {
        if (collision.gameObject.name == "goal")//�G�ꂽ�I�u�W�F�N�g�̖��O��gole�Ȃ�
        {
            Destroy(GetComponent<Rigidbody>());//Rigidbody������
            GetComponent<Jump>().enabled = false;//�N���A������Jump���~
        }


        if (collision.gameObject.tag == "Ground")//�G�ꂽ�I�u�W�F�N�g�̖��O��gole�Ȃ�
        {
            Jp = 0;
        }
    }

}