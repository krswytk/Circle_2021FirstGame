using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_script : MonoBehaviour

{
    private Rigidbody2D rb;
    private Vector3 force;
    private bool isGround;//地面についてるかどうかの判定
    private bool slidingflg;//スライディング状態かどうかの判定
    public GameObject TextGameover;//gameoverテキスト
    public GameObject canvas;
    private Transform TextScore;//Scoreテキスト
    private Score score;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        animator.SetTrigger("start");
        canvas = GameObject.Find("Canvas");
        TextScore = canvas.transform.Find("Score");//scoreを探す
        rb = this.GetComponent<Rigidbody2D>();
        score = TextScore.GetComponent<Score>();
        isGround = true;
        this.gameObject.layer = 7;//runlayerに設定する
        TextScore.gameObject.SetActive(true);//textscoreを表示する
        force = new Vector3(1.0f, 0.0f, 0.0f);//forceの初期設定
        slidingflg = false;//スライディング実行かどうか
        TextGameover.SetActive(false);//textgameoverを非表示にする
        
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(0.03f, 0f, 0f);
        force = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Debug.Log("j");
            jump();
        }
        if (Input.GetKey(KeyCode.S) && slidingflg)
        {
            sliding();
        }
        rb.AddForce(force);
    }
    void jump()
    {
        animator.SetTrigger("Jump");
        force.y += 1000.0f;
        isGround = false;
    }
    void sliding()
    {
        animator.SetTrigger("sliding");
        gameObject.layer = 8;//layerをスライディングに変更する
        slidingflg = false;//スライディング入力を不可能にする
    }
    void Gameover()
    {
        animator.SetTrigger("GameOverAnimation");
        TextGameover.SetActive(true);//GameOverを表示する
        score.isclear=true;
    }
    void OnTriggerStay2D(Collider2D collision)//何かに触れたとき
    {
        if (collision.gameObject.tag =="SlidingS")//触れたオブジェクトの名前がslidingSなら
        {
            slidingflg = true;//スライディング入力を可能にする
        }
        if (collision.gameObject.tag=="SlidingE")
        {
            this.gameObject.layer = 7;//layerをrunに変更する
        }
        
        if(collision.gameObject.tag=="hawk")
        {
            Gameover();
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Gameover();
        }
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}