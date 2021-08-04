using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    float walkForce = 20.0f;
    [SerializeField]
    float minWalkTime = 3.0f;
    [SerializeField]
    float maxWalkTime = 5.0f;
    [SerializeField]
    float minIdleTime = 3.0f;
    [SerializeField]
    float maxIdleTime = 5.0f;
    [SerializeField]
    float minRotateAngle = -60.0f;
    [SerializeField]
    float maxRotateAngle = 60.0f;
    [SerializeField]
    float deadSpeed = 50.0f;
    [SerializeField]
    float walkAnimationSpeed = 2.0f;
    [SerializeField]
    float impulse = 300;

    bool isDead = false;
    bool isWalk = false;
    bool isCollision = false;

    Animator animator;
    Rigidbody rigidBody;
    Rigidbody playerRigidBody;
    CapsuleCollider capsuleCollider;
    BoxCollider boxCollider;
    GameObject player;

    void Start()
    {
        //ゾンビ自身のコンポーネントを取得
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        boxCollider = GetComponent<BoxCollider>();

        //プレイヤーをタグで検索し、Rigidbodyを取得
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody>();

        StartCoroutine(ZombieBehavior());
    }

    //歩く処理
    void Walk()
    {
        //方向転換（Y軸ランダム回転）
        float angle = Random.Range(minRotateAngle, maxRotateAngle);
        transform.Rotate(0, angle, 0);

        animator.speed = walkAnimationSpeed;
        animator.SetBool("IsWalk", true);
    }

    //待機処理
    void Idle()
    {
        rigidBody.velocity = Vector3.zero;
        animator.speed = 1;
        animator.SetBool("IsWalk", false);
    }

    //コルーチン
    IEnumerator ZombieBehavior()
    {
        while (isDead == false)
        {
            float idleTime = Random.Range(minIdleTime, maxIdleTime);
            Idle();
            yield return new WaitForSeconds(idleTime);

            float walkTime = Random.Range(minWalkTime, maxWalkTime);
            Walk();
            isWalk = true;
            yield return new WaitForSeconds(walkTime);
            isWalk = false;
        }
    }

    void FixedUpdate()
    {
        if (isWalk)
        {
            rigidBody.AddForce(transform.forward * walkForce);
        }
    }

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        //一定速度以上の速度を出しているプレイヤーと接触したら倒れる
        //ただし、一度倒れたらこの処理はしない
        if (collision.gameObject.tag == "Player" && isCollision == false)
        {
            float playerSpeed = playerRigidBody.velocity.magnitude;
            if (playerSpeed >= deadSpeed)
            {
                //倒れないようにしているのを解除
                rigidBody.freezeRotation = false;

                //吹っ飛ばす
                //※後で追加します

                //コライダーを切り替え
                capsuleCollider.enabled = false;
                boxCollider.enabled = true;

                //フラグON
                isDead = true;
                isCollision = true;
                animator.speed = 1;
                animator.SetBool("IsDead", true);
            }
        }
    }
}