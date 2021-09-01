//�X�e�[�W1�̃��U���g��ʃv���O�����̒���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1result : MonoBehaviour
{
    int result;
    int HRs; //�n�C�X�R�A�i�[�֐�
    public static int HR; //�n�C�����N����֐�
    [SerializeField] GameObject spaceanim; //�A�j���[�V��������\��̃I�u�W�F�N�g�w��
    public AudioClip E; //11�`13�s�ځA�������y�̑I��g
    public AudioClip G;
    public AudioClip R;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        result = Stage1score.S1score; //�X�e�[�W1�̃X�R�A��ʂ̃X�N���v�g����Q��
        if (HRs < Stage1score.S1score) //�����X�R�A���Ō�Ɏ��������荂��������n�C�X�R�A�Ƃ��ē���ւ���
        {
            HRs = Stage1score.S1score;

        }
        //�����ŃX�R�A�ɂ���ă����N��������(80%�ȏ�ŗǁA50%�ȏ�ŉA���ꖢ���͕s)
        if (HRs >= 51)
        {
            HR = 2;
        }
        else if (HRs >= 32)
        {
            HR = 1;
        }
        else
        {
            HR = 0;
        }
        audioSource = GetComponent<AudioSource>();
        //���U���g�A�j���[�V�����Đ�
        Invoke("Result", 1f);
        Invoke("Result2", 3f);
        Invoke("ResultM", 4.5f);
        StartCoroutine("Spaceanim");

    }

    // Update is called once per frame
    void Update() //�X�y�[�X�L�[����������X�e�[�W�Z���N�g��ʂ܂Ŗ߂�
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeManager.Instance.LoadScene("StageSelect", 1f);
        }
        
    }

    void Result() //�_���ɂ��]���̃R�����g���蕔��
    {
        if (result >= 51)
        {
            GameObject S1Result = (GameObject)Resources.Load("S1CommentsE");
            GameObject instance = (GameObject)Instantiate(S1Result, new Vector3(0f, 1f, 0f), Quaternion.Euler(0f,0f,180f));
            
        }
        else if (result >= 32)
        {
            GameObject S1Result = (GameObject)Resources.Load("S1CommentsG");
            GameObject instance = (GameObject)Instantiate(S1Result, new Vector3(0f, 1f, 0f), Quaternion.Euler(0f, 0f, 180f));
        }
        else
        {
            GameObject S1Result = (GameObject)Resources.Load("S1CommentsR");
            GameObject instance = (GameObject)Instantiate(S1Result, new Vector3(0f, 1f, 0f), Quaternion.Euler(0f, 0f, 180f));
        }
    }

    void Result2() //�_���ɂ��]���\������
    {
        if (result >= 51)
        {
            GameObject S1Result2 = (GameObject)Resources.Load("ResultE");
            GameObject instance = (GameObject)Instantiate(S1Result2, new Vector3(0f, -1.2f, 0f), Quaternion.identity);

        }
        else if (result >= 32)
        {
            GameObject S1Result2 = (GameObject)Resources.Load("ResultG");
            GameObject instance = (GameObject)Instantiate(S1Result2, new Vector3(0f, -1.2f, 0f), Quaternion.identity);
        }
        else
        {
            GameObject S1Result2 = (GameObject)Resources.Load("ResultR");
            GameObject instance = (GameObject)Instantiate(S1Result2, new Vector3(0f, -1.2f, 0f), Quaternion.identity);
        }
    }

    void ResultM() //���U���g���y���蕔��
    {
        if (result >= 51)
        {
            audioSource.PlayOneShot(E);
        }
        else if (result >= 32)
        {
            audioSource.PlayOneShot(G);
        }
        else
        {
            audioSource.PlayOneShot(R);
        }
    }

    IEnumerator Spaceanim() //�R���[�`���֐����g�����I�u�W�F�N�g�̓_�ŏ���
    {
        yield return new WaitForSeconds(6.5f);
        yield return null;
        spaceanim.SetActive(true);
        while (true)
        {
            
            yield return new WaitForSeconds(0.5f);
            yield return null;
            spaceanim.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            yield return null;
            spaceanim.SetActive(true);

        }
    }

    
}
