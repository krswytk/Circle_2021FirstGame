using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CharacterController������
[RequireComponent(typeof(CharacterController))]

public class FirstPerson : MonoBehaviour
{
    private float speed;
    //�����鑬���A�d��
    public float gravity = 10f;
    private float jumpSpeed;

    //�ʏ펞�̃X�s�[�h�ƃW�����v��
    public float normalSpeed = 5;
    public float normalJump = 10;
    //��Shift�������Ƃ��̃X�s�[�h�ƃW�����v��
    public float shiftSpeed = 10;
    public float shiftJump = 20;

    //Player�̈ړ����������������
    Vector3 moveDirection;

    //CharacterController��ϐ��ɂ���
    CharacterController controller;

    //�}�E�X�̉��c�ɓ���������
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    //Main Camera������
    GameObject came;

    //�W�����v�{�^�����������Ƃ𔻒�
    //��i�W�����v��h������
    private bool jumpUpEnd = false;

    //�W�����v�{�^�������Ă��鎞�Ԃ𔻒�
    //���̎��Ԃ𐧌����邽��
    [SerializeField] float jumpTime;

    void Start()
    {
        //CharacterController���擾
        controller = GetComponent<CharacterController>();

        //Main Camera���������q�I�u�W�F�N�g�ɂ���Player�ɐݒu����
        came = Camera.main.gameObject;
        came.transform.parent = this.transform;
        //�J������ڐ��̍����ɂ���
        came.transform.localPosition = new Vector3(0, 0.4f, 0);
        //�J�����̌��������̃I�u�W�F�N�g�Ɠ����ɂ���
        came.transform.rotation = this.transform.rotation;
    }

    void Update()
    {
        //���E�ǂ��炩��Shift�������ꍇ�Ɨ����Ă���ꍇ
        if (Input.GetKey(KeyCode.LeftShift)
            || Input.GetKey(KeyCode.RightShift))
        {
            speed = shiftSpeed;
            jumpSpeed = shiftJump;
        }
        else
        {
            speed = normalSpeed;
            jumpSpeed = normalJump;
        }

        //�}�E�X�ŃJ�����̌�����Player�̉��̌�����ς���
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);
        came.transform.Rotate(-v, 0, 0);

        //Player���n�ʂɐݒu���Ă��邱�Ƃ𔻒�
        if (controller.isGrounded)
        {
            //XZ���̈ړ��ƌ�����������
            //WASD,�㉺���E�L�[
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
                                    Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Y�������ɃW�����v������
            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;

            //�W�����v���Ɋւ��ϐ�
            //�n�ʂɂ��Ă��鎞�Ƀ��Z�b�g
            jumpUpEnd = false;
            jumpTime = 0;
        }
        else
        {
            //�W�����v�{�^�������Ă���Ə㏸
            //�����Ă��鎞��3�b�܂ŁAjumpUpEnd��false�̏ꍇ�L��


            //�W�����v���ɃW�����v�{�^�����������Ƃ��L�^
            //jumpUpEnd��false�̏ꍇ�L��
            if (Input.GetButtonUp("Jump") && !jumpUpEnd)
            {
                //���W�����v�ł��Ȃ�����
                jumpUpEnd = true;
            }
        }

        // �d�͂�ݒ肵�Ȃ��Ɨ������Ȃ�
        moveDirection.y -= gravity * Time.deltaTime;

        // Move�֐��ɑ������
        controller.Move(moveDirection * Time.deltaTime);
    }
}