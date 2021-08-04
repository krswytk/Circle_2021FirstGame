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
        //�]���r���g�̃R���|�[�l���g���擾
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        boxCollider = GetComponent<BoxCollider>();

        //�v���C���[���^�O�Ō������ARigidbody���擾
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody>();

        StartCoroutine(ZombieBehavior());
    }

    //��������
    void Walk()
    {
        //�����]���iY�������_����]�j
        float angle = Random.Range(minRotateAngle, maxRotateAngle);
        transform.Rotate(0, angle, 0);

        animator.speed = walkAnimationSpeed;
        animator.SetBool("IsWalk", true);
    }

    //�ҋ@����
    void Idle()
    {
        rigidBody.velocity = Vector3.zero;
        animator.speed = 1;
        animator.SetBool("IsWalk", false);
    }

    //�R���[�`��
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

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        //��葬�x�ȏ�̑��x���o���Ă���v���C���[�ƐڐG������|���
        //�������A��x�|�ꂽ�炱�̏����͂��Ȃ�
        if (collision.gameObject.tag == "Player" && isCollision == false)
        {
            float playerSpeed = playerRigidBody.velocity.magnitude;
            if (playerSpeed >= deadSpeed)
            {
                //�|��Ȃ��悤�ɂ��Ă���̂�����
                rigidBody.freezeRotation = false;

                //������΂�
                //����Œǉ����܂�

                //�R���C�_�[��؂�ւ�
                capsuleCollider.enabled = false;
                boxCollider.enabled = true;

                //�t���OON
                isDead = true;
                isCollision = true;
                animator.speed = 1;
                animator.SetBool("IsDead", true);
            }
        }
    }
}