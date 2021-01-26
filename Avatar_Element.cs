using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar_Element : MonoBehaviour
{
    public SpriteRenderer testRenderer;
    public int MAX_IDX;
    public Sprite[] avatar;

    void Start()
    {
        MAX_IDX = avatar.Length;
    }

    public void TestSet(int idx)//pivot, 스프라이트 합체 확인용 함수
    {
        if(idx<MAX_IDX)
        {
            testRenderer.sprite = avatar[idx];
        }
        else
        {
            Debug.LogError("인덱스 값이 범위를 넘어섬");
        }
    }
}
