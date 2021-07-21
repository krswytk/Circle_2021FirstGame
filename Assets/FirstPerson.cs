using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CharacterControllerを入れる
[RequireComponent(typeof(CharacterController))]

public class FirstPerson : MonoBehaviour
{
    private float speed;
    //落ちる速さ、重力
    public float gravity = 10f;
    private float jumpSpeed;

    //通常時のスピードとジャンプ力
    public float normalSpeed = 5;
    public float normalJump = 10;
    //左Shift押したときのスピードとジャンプ力
    public float shiftSpeed = 10;
    public float shiftJump = 20;

    //Playerの移動や向く方向を入れる
    Vector3 moveDirection;

    //CharacterControllerを変数にする
    CharacterController controller;

    //マウスの横縦に動かす速さ
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    //Main Cameraを入れる
    GameObject came;

    //ジャンプボタン離したことを判定
    //二段ジャンプを防ぐため
    private bool jumpUpEnd = false;

    //ジャンプボタン押している時間を判定
    //その時間を制限するため
    [SerializeField] float jumpTime;

    void Start()
    {
        //CharacterControllerを取得
        controller = GetComponent<CharacterController>();

        //Main Cameraを検索し子オブジェクトにしてPlayerに設置する
        came = Camera.main.gameObject;
        came.transform.parent = this.transform;
        //カメラを目線の高さにする
        came.transform.localPosition = new Vector3(0, 0.4f, 0);
        //カメラの向きをこのオブジェクトと同じにする
        came.transform.rotation = this.transform.rotation;
    }

    void Update()
    {
        //左右どちらかのShift押した場合と離している場合
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

        //マウスでカメラの向きとPlayerの横の向きを変える
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);
        came.transform.Rotate(-v, 0, 0);

        //Playerが地面に設置していることを判定
        if (controller.isGrounded)
        {
            //XZ軸の移動と向きを代入する
            //WASD,上下左右キー
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
                                    Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Y軸方向にジャンプさせる
            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;

            //ジャンプ中に関わる変数
            //地面についている時にリセット
            jumpUpEnd = false;
            jumpTime = 0;
        }
        else
        {
            //ジャンプボタン押していると上昇
            //押している時間3秒まで、jumpUpEndがfalseの場合有効


            //ジャンプ中にジャンプボタン離したことを記録
            //jumpUpEndがfalseの場合有効
            if (Input.GetButtonUp("Jump") && !jumpUpEnd)
            {
                //二回ジャンプできなくする
                jumpUpEnd = true;
            }
        }

        // 重力を設定しないと落下しない
        moveDirection.y -= gravity * Time.deltaTime;

        // Move関数に代入する
        controller.Move(moveDirection * Time.deltaTime);
    }
}