using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Avatar_Part
{
    public Avatar_Part_CODE code;
    public Avatar_Part_Base part;
}


public class Avatar_Base : MonoBehaviour
{
    //스프라이트 Index 비교
    private int oldIndex = 0;
    public int index = 0;

    [SerializeField]
    Avatar_Part[] parts = null;

    [Header("Shadow")]
    [SerializeField]
    RenderTexture shadow_RenTex = null;

    [SerializeField]
    Camera shadow_Cam;

    [SerializeField]
    SpriteRenderer shadow_Renderer = null;




    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //아바타 기능이 잘 동작하는지 확인을 위한 코드
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            if (241 < index) index = 241;
            DrawSprite(index);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            index--;
            if (index < 0) index = 0;
            DrawSprite(index);
        }
        */

        if (oldIndex != index) DrawSprite(index);
    }

    public virtual void Init()  //초기화를 위한 함수
    {
        for(int i=0;i<parts.Length;i++)
        {
            parts[i].part.Init();
        }

        index = 0;
        oldIndex = index;
        DrawSprite(index);
    }

    public void DrawSprite(int idx)
    {
        if(oldIndex!=idx)
        {
            index = idx;
            oldIndex = index;
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].part.DrawSprite(index);
            }
        }
        Set_Shadow();
    }

    public virtual void SetAvatar(Avatar_Group_Base avatar, Avatar_Part_CODE code)
    {
        for(int i=0; i < parts.Length; i++)
        {
            if(parts[i].code == code)
            {
                parts[i].part.SetAvatar(avatar);
                return;
            }
        }
    }

    public void Set_Shadow() //렌더 텍스쳐를 이용해 스프라이트를 만들어 그림자를 만드는 함수
    {
        
        Texture2D tex = new Texture2D(shadow_RenTex.width, shadow_RenTex.height, TextureFormat.RGBA32, false);

        RenderTexture.active = shadow_RenTex;

        Rect temprect = new Rect(0, 0, shadow_RenTex.width, shadow_RenTex.height);

        shadow_Cam.Render();

        tex.ReadPixels(temprect, 0, 0, false);
        tex.Apply();
        Sprite temp = Sprite.Create(tex, temprect, new Vector2(0.51875f, 0));

        shadow_Renderer.sprite = temp;

        RenderTexture.active = null;
    }
}

