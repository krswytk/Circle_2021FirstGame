using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamp : MonoBehaviour

{
    private Rigidbody2D rb;
    private Vector3 force;
    public bool isGround;
    public bool slidingflg;
    private const float ACTION_TIME = 1f;
    private float _actionTime;
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
        this.gameObject.layer = 7;
        rb = this.GetComponent<Rigidbody2D>();
        force = new Vector3(1.0f, 0.0f, 0.0f);
        slidingflg = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(0.01f, 0f, 0f);
        force = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            force.y += 400.0f;
            isGround = false;
        }
        if (Input.GetKey(KeyCode.S) && slidingflg)
        {
            gameObject.layer = 8;
            slidingflg = false;
        }
        rb.AddForce(force);
        Debug.Log("触れていません");
    }
    void OnTriggerStay2D(Collider2D collision)//何かに触れたとき
    {
        Debug.Log("触れています");
        if (collision.gameObject.tag =="SlidingS")//触れたオブジェクトの名前がgoleなら
        {
            slidingflg = true;
        }
        if (collision.gameObject.tag=="SlidingE")
        {
            this.gameObject.layer = 7;
        }


    }
}