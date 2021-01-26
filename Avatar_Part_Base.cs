using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class Avatar_Part_Member
{
    public Avatar_Element_CODE code = Avatar_Element_CODE.A;
    public SpriteRenderer renderer = null;
    public Avatar_Element element = null;

    public void Draw(int idx)
    {
        if (element == null)                        renderer.sprite = null;
        else if (idx < element.avatar.Length)       renderer.sprite = element.avatar[idx]; 
        else                                        Debug.LogError("전달받은 idx값이 배열을 넘어섬");
    }
}

public class Avatar_Part_Base : MonoBehaviour
{
    public Avatar_Group_Base avatar_Default = null;
    public Avatar_Group_Base avatar = null;
    private int index = 0;
    [SerializeField]
    Avatar_Part_Member[] members = null;



    public virtual void Init()
    {
        SetAvatar(null);
    }

    public virtual void DrawSprite(int idx)
    {
        index = idx;

        for(int i = 0; i < members.Length; i++)
        {
            members[i].Draw(index);
        }
    }

    public virtual void SetAvatar(Avatar_Group_Base avt)
    {
        if (avt == null) avatar = avatar_Default;     //아바타 칸이 비워질시 기본 아바타 데이터로 교체
        else             avatar = avt;

        if (avatar == null)        //기본 아바타 정보도 없다면 하위 멤버들도 정보를 없애기
        {
            for (int i = 0; i < members.Length; i++)
            {
                members[i].element = null;
            }
        }
        else
        {
            for (int i = 0; i < members.Length; i++)    //레이어에 맞는 element 연결하기
            {
                members[i].element = null;
                
                for (int j = 0; j < avatar.avatar_Members.Length; j++)
                {
                    if (members[i].code == avatar.avatar_Members[j].code)
                    {
                        members[i].element = avatar.avatar_Members[j].element;
                        break;
                    }
                }
            } 
        }

        DrawSprite(index);       //새롭게 바뀐 아바타에 맞춰서 새로 스프라이트 그리기
    }
}
