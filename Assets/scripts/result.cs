using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class result : MonoBehaviour
{
    private string keep;
    private string path;
    private int[] targetArray;
    void Start()
    {
        path = Application.persistentDataPath + "/result.txt";
        targetArray = new int[] { 0, 0, 0, 0, 0, 0 };// �\�[�g�������z����`���܂��B
        Openfile();
        ExecuteSort();
    }
    void Openfile()
    {
        if (!(System.IO.File.Exists(path)))//result�����݂��Ă��邩
        {
            System.IO.File.Create(path);//���݂��Ă��Ȃ��Ȃ琶������
            for (int i = 0; i < 5; i++)
            {
                File.AppendAllText(path, "0");
            }
            
        }
       //��s���ǂݍ���
        using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            for (int i = 0; i < 5; i++)
            {
                if (fs.Peek() != -1)
                {
                keep = fs.ReadLine();
                targetArray[i] = Convert.ToInt32(keep);
                }
                else
                {
                break;
                }
            }
        }
    }
    void ExecuteSort()
    {
        // �����񐔂�ێ�����ϐ��ł��B
        int iterationNum = 0;
            // �}���\�[�g�Ŕz��̒��g����בւ��܂��B
        for (int i = 1; i < targetArray.Length; i++)
        {
            // ��r���s���l��ێ�����ϐ��ł��B
            int key = targetArray[i];

            // �ړ���̃C���f�b�N�X��ێ�����ϐ��ł��B
            int destIndex = i;

            // �v�f�̔�r���s���܂��B
            for (int j = i - 1; j >= 0; j--)
            {
                 // �����񐔂̒l�𑝂₵�܂��B
                iterationNum++;
                // �L�[�Ɣ�r���A�L�[���傫�Ȓl�ł���Ύ��̗v�f�ɒl�����炵�܂��B
                if (targetArray[j] > key)
                {
                    targetArray[j + 1] = targetArray[j];
                    // �����𖞂����Ă��鎞�̃C���f�b�N�X���ړ���Ƃ��ĕۑ����܂��B
                    destIndex = j;
                }
            }
                // �ۑ������l���m�F���̗v�f�ɑ}�����܂��B
                targetArray[destIndex] = key;
        }

    }
}

