using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercamera : MonoBehaviour
{
    public GameObject player;

    private Transform mytrn;

    private Transform playertrn;

    private Vector3 mypos;

    private Vector3 playerpos;

    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        mytrn = this.transform;

        mypos = mytrn.position;//�J�����̏����ʒu

        playertrn = player.transform;
        playerpos = playertrn.position;//Player�̏����ʒu

        //�J������Player�̈ʒu�֌W�𑪒�
        x = mypos.x - playerpos.x;
        y = mypos.y - playerpos.y;
        z = mypos.z - playerpos.z;
    }

    // Update is called once per frame
    void Update()
    {
        playertrn = player.transform;
        playerpos = playertrn.position;//Player�̌��ݒl����

        //�J�����Ƃ̈ʒu�֌W�����
        playerpos.x += x;
        playerpos.y += y;
        playerpos.z += z;

        mytrn.position = playerpos;//�J�����̈ʒu��ύX
    }
}