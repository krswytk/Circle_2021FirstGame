using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jamp : MonoBehaviour
{
    public static int Result;

    float up = 0.1f;
    float right = 0.05f;

    // 辞書型の変数を使ってます。
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

    private void OnCollisionEnter(Collision collision)//何かに触れたとき
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
                
            
            Destroy(GetComponent<Rigidbody>());//Rigidbodyを消す
            Invoke("DelayMethod", 3.5f);

        }

        if (collision.gameObject.tag == "Goal")//触れたオブジェクトの名前がgoalなら
        {
            Destroy(GetComponent<Rigidbody>());//Rigidbodyを消す
        }
        
    }
    void DelayMethod()
    {
        SceneManager.LoadScene("result2");
    }
}