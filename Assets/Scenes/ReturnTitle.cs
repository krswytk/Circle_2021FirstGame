using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���}�l�W�����g��L���ɂ���

public class ReturnTitle : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if ( Input.GetKeyDown("space"))//�}�E�X���N���b�N�A�X�y�[�X�L�[�AA�{�^���A�W�����v�{�^�����������ꍇ
		{
			SceneManager.LoadScene("SampleScene");//some_sensei�V�[�������[�h����
		}

	}
}