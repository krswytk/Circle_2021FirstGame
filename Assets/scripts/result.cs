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
        targetArray = new int[] { 0, 0, 0, 0, 0, 0 };// ソートしたい配列を定義します。
        Openfile();
        ExecuteSort();
    }
    void Openfile()
    {
        if (!(System.IO.File.Exists(path)))//resultが存在しているか
        {
            System.IO.File.Create(path);//存在していないなら生成する
            for (int i = 0; i < 5; i++)
            {
                File.AppendAllText(path, "0");
            }
            
        }
       //一行ずつ読み込む
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
        // 処理回数を保持する変数です。
        int iterationNum = 0;
            // 挿入ソートで配列の中身を並べ替えます。
        for (int i = 1; i < targetArray.Length; i++)
        {
            // 比較を行う値を保持する変数です。
            int key = targetArray[i];

            // 移動先のインデックスを保持する変数です。
            int destIndex = i;

            // 要素の比較を行います。
            for (int j = i - 1; j >= 0; j--)
            {
                 // 処理回数の値を増やします。
                iterationNum++;
                // キーと比較し、キーより大きな値であれば次の要素に値をずらします。
                if (targetArray[j] > key)
                {
                    targetArray[j + 1] = targetArray[j];
                    // 条件を満たしている時のインデックスを移動先として保存します。
                    destIndex = j;
                }
            }
                // 保存した値を確認中の要素に挿入します。
                targetArray[destIndex] = key;
        }

    }
}

