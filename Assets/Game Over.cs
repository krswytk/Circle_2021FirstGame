using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public GameObject TextGame Over;
    public GameObject Player;
    private bool rs;

    //�ǉ�
    public GameObject Textzanki;
    public int zanki;
    private Text tzanki;
    //�ǉ�
    // Start is called before the first frame update
    void Start()
    {
        //�ǉ�
        zanki = 5;
        tzanki = Textzanki.GetComponent<Text>();
        //�ǉ�
        rs = false;
        Textzanki.SetActive(true);
        TextGameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�ǉ�
        tzanki.text = "�c�@ x " + zanki.ToString();
        //�ǉ�
        if (rs == true)
        {
            //�ǉ�
            zanki = 0;
            //�ǉ�
            TextGameover.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //�ǉ�
        Failed();
        //�ǉ�
    }
    //�ǉ�
    public void Failed()
    {
        zanki--;
        if (zanki < 0)//�c�@���}�C�i�X�ɂȂ�����
        {
            rs = true;
            Player.GetComponent<Jump>().enabled = false;//�Q�[���I�[�o�[�ŃW�����v���~
        }
        else
        {
            Player.transform.position = new Vector3(2.79f, 19.18f, 0.0f);//�����ʒu�ɖ߂�
            Player.transform.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            //Player�̑��x��0�ɂ���i��������ǂ��Ȃ邩�\�z���悤�I�j
        }
    }
    //�ǉ�

    //����Ă��邱�Ƃ�Cointext�Ɩw�Ǔ��������番����Ȃ��Ȃ�����U��Ԃ��Ă݂悤�I�I�I

}

