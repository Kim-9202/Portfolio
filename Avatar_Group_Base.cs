using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Avatar_Group_Member
{
    public Avatar_Element_CODE code;
    public Avatar_Element element;
}

public class Avatar_Group_Base : MonoBehaviour
{
    public Avatar_Part_CODE part_Code;

    public Sprite Icon;

    public int MaxIdx = 242;

    [SerializeField]
    public Avatar_Group_Member[] avatar_Members;

    private void Start()
    {
        //StartCoroutine(TestAnim());
    }

    IEnumerator TestAnim()  //pivot, 스프라이트 합체 확인용 코루틴
    {
        int idx = 0;
        while (true)
        {

            for (int i = 0; i < avatar_Members.Length; i++)
            {
                if(avatar_Members[i].element != null)
                {
                    avatar_Members[i].element.TestSet(idx);
                }
            }

            idx++;
            if (MaxIdx < idx) idx = 0;
            yield return new WaitForSeconds(0.5f);
        }
        
    }

}
