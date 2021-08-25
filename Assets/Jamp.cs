using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jamp : MonoBehaviour
{
    public static int Result;

    float up = 0.1f;
    float right = 0.05f;

    // �����^�̕ϐ����g���Ă܂��B
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"up", false },
        {"down", false },
        {"right", false },
        {"left", false },
    };

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move["up"] = Input.GetKey(KeyCode.UpArrow);
        move["down"] = Input.GetKey(KeyCode.DownArrow);
        move["right"] = Input.GetKey(KeyCode.RightArrow);
        move["left"] = Input.GetKey(KeyCode.LeftArrow);
        
        
    }

    void FixedUpdate()
    {
        if (move["up"])
        {
            transform.Translate(0f, up, 0f);
        }
        if (move["down"])
        {
            transform.Translate(0f, -up, 0f);
        }
        if (move["right"])
        {
            transform.Translate(right, 0f, 0f);
        }
        if (move["left"])
        {
            transform.Translate(-right, 0f, 0f);
        }
        
            transform.Translate(0f, -0.03f, 0f);

        
    }

    private void OnCollisionEnter(Collision collision)//�����ɐG�ꂽ�Ƃ�
    {
        if (collision.gameObject.tag == "Enemy")//
        {
            if (move["up"])
            {
                transform.Translate(0f, -25*up, 0f);
            }
            if (move["down"])
            {
                transform.Translate(0f, 25*up, 0f);
            }
            if (move["right"])
            {
                transform.Translate(-25*right, 0f, 0f);
            }
            if (move["left"])
            {
                transform.Translate(25*right, 0f, 0f);
            }

            
                Result = -1;
                
            
            Destroy(GetComponent<Rigidbody>());//Rigidbody������
            Invoke("DelayMethod", 3.5f);

        }

        if (collision.gameObject.tag == "Goal")//�G�ꂽ�I�u�W�F�N�g�̖��O��goal�Ȃ�
        {
            Destroy(GetComponent<Rigidbody>());//Rigidbody������
        }
        
    }
    void DelayMethod()
    {
        SceneManager.LoadScene("result2");
    }
}