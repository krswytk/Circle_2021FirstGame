//ImageExt.cs
// author: trpla226
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class ImageExt
{

    // Start is called before the first frame update

    /// <summary>
    /// Image�̕s�����x��ݒ肷��
    /// </summary>
    /// <param name="image">�ݒ�Ώۂ�Image�R���|�[�l���g(this)</param>
    /// <param name="alpha">�s�����x�B0=���� 1=�s����</param>
    public static void SetOpacity(this Image image, float alpha)
    {
        Application.targetFrameRate = 60;
        var c = image.color;
        image.color = new Color(c.r, c.g, c.b, alpha);
    }
}
