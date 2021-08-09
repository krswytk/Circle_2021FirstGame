using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_script : MonoBehaviour

{
    private Rigidbody2D rb;
    private Vector3 force;
    private bool isGround;//�n�ʂɂ��Ă邩�ǂ����̔���
    private bool slidingflg;//�X���C�f�B���O��Ԃ��ǂ����̔���
    public GameObject TextGameover;//gameover�e�L�X�g
    public GameObject canvas;
    private Transform TextScore;//Score�e�L�X�g
    private Score score;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        animator.SetTrigger("start");
        canvas = GameObject.Find("Canvas");
        TextScore = canvas.transform.Find("Score");//score��T��
        rb = this.GetComponent<Rigidbody2D>();
        score = TextScore.GetComponent<Score>();
        isGround = true;
        this.gameObject.layer = 7;//runlayer�ɐݒ肷��
        TextScore.gameObject.SetActive(true);//textscore��\������
        force = new Vector3(1.0f, 0.0f, 0.0f);//force�̏����ݒ�
        slidingflg = false;//�X���C�f�B���O���s���ǂ���
        TextGameover.SetActive(false);//textgameover���\���ɂ���
        
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
        gameObject.layer = 8;//layer���X���C�f�B���O�ɕύX����
        slidingflg = false;//�X���C�f�B���O���͂�s�\�ɂ���
    }
    void Gameover()
    {
        animator.SetTrigger("GameOverAnimation");
        TextGameover.SetActive(true);//GameOver��\������
        score.isclear=true;
    }
    void OnTriggerStay2D(Collider2D collision)//�����ɐG�ꂽ�Ƃ�
    {
        if (collision.gameObject.tag =="SlidingS")//�G�ꂽ�I�u�W�F�N�g�̖��O��slidingS�Ȃ�
        {
            slidingflg = true;//�X���C�f�B���O���͂��\�ɂ���
        }
        if (collision.gameObject.tag=="SlidingE")
        {
            this.gameObject.layer = 7;//layer��run�ɕύX����
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