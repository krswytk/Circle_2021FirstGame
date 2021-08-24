using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_script : MonoBehaviour

{
    private Rigidbody2D rb;
    private Vector3 force_Vec;
    private bool isGround_bool;//地面についてるかどうかの判定
    //private bool slidingflg_bool;//スライディング状態かどうかの判定
    Animator animator;
    
    public static float speed_f;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        animator.SetTrigger("start"); 
        rb = this.GetComponent<Rigidbody2D>();
        isGround_bool = true;
        this.gameObject.layer = 7;//runlayerに設定する
        force_Vec = new Vector3(1.0f, 0.0f, 0.0f);//forceの初期設定
        //slidingflg_bool = true;//スライディング実行かどうか
        speed_f = 0.05f;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(speed_f, 0f, 0f);
        force_Vec = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.Space) && isGround_bool)
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sliding();
        }
        rb.AddForce(force_Vec);
        
    }
    private void jump()
    {  
        animator.SetTrigger("Jump");
        force_Vec.y += 500.0f;
        rb.AddForce(force_Vec);
        force_Vec.y +=0f;
        isGround_bool = false;
    }
    public void gameover()
    {
        animator.SetTrigger("GameOverAnimation");
        speed_f = 0;
        this.GetComponent<player_script>().enabled = false;
    }
    public void cliar()
    {
        animator.SetTrigger("player-idle-1");
        speed_f = 0;
        this.GetComponent<player_script>().enabled = false;
    }
    private void sliding()
    {
        animator.SetTrigger("sliding");
        //slidingflg_bool = false;
        gameObject.layer = 8;//layerをスライディングに変更する
    }
    void slidingend()
    {
        this.gameObject.layer = 7;//layerをrunに変更する
    }
    private void OnTriggerStay2D(Collider2D collision)//何かに触れたとき
    {
        
        if (collision.gameObject.tag == "hall")
        {
            speed_f = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround_bool = true;
        }
        
    }
}