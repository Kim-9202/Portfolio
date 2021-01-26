using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]
public class Item
{
    public enum GRADE { COMMON = 0, UNCOMMON = 1, RARE = 2, UNIQUE = 3, LEGENDERY = 4, EPIC = 5 };
    public enum KIND { EQUIPMENT = 0, CONSUMABLES = 1, MATERIAL = 2, QUESTITEM = 3, AVATAR = 4 };

    [SerializeField]
    public String Name;

    public ITEM_CODE Code;

    [SerializeField]
    public GRADE Grade;

    [SerializeField]
    public KIND Kind;

    [SerializeField]
    public String Explanation;

    [SerializeField]
    public Sprite DropSprite, Icon;

    public int maxQuantity;

    public float cool;

    public Item(String name, ITEM_CODE code, GRADE grade, KIND kind, String Exp)
    {
        Name = name;
        Code = code;
        Grade = grade;
        Kind = kind;
        Explanation = Exp;
        cool = 0;
    }

    public Item(ITEM_CODE code, KIND kind)
    {
        Code = code;
        Kind = kind;
        cool = 0;
    }

    public virtual void UseItem()
    {

    }
}

///////////////////장비아이템
[Serializable]
public class Equipment : Item   
{
    public enum EQUIPPARTS { COAT = 0, PANTS = 1, NECK = 2, BELT = 3, SHOES = 4 };

    public EQUIPPARTS Parts;

    public SET_SKILL_CODE set_Code;


    public Equipment(String name, ITEM_CODE code, GRADE grade, String Exp, SET_SKILL_CODE set_Code) : base(name, code, grade, KIND.EQUIPMENT, Exp)
    {
        this.set_Code = set_Code;
    }

    public Equipment(ITEM_CODE code, SET_SKILL_CODE set_Code) : base(code ,KIND.EQUIPMENT)
    { 
        this.set_Code = set_Code;
    }

    public Equipment(ITEM_CODE code, EQUIPPARTS parts, SET_SKILL_CODE set_Code) : base(code, KIND.EQUIPMENT)
    {
        Parts = parts;
        this.set_Code = set_Code;
    }

    public virtual void Equip()
    {
        if(set_Code!=SET_SKILL_CODE.NONE)
        {
            Set_Skill_MGR.instance.Equip_Set_Item(set_Code);
        }
    }

    public virtual void Unequip()
    {
        if (set_Code != SET_SKILL_CODE.NONE)
        {
            Set_Skill_MGR.instance.Unequip_Set_Item(set_Code);
        }
    }
}

[Serializable]
public class Coat : Equipment
{
    public float defense;


    public Coat(ITEM_CODE code, SET_SKILL_CODE set_Code) : base(code, EQUIPPARTS.COAT, set_Code)
    { }


}

public class Coat_Satan : Coat
{
    public Coat_Satan() :base(ITEM_CODE.COAT_Satan, SET_SKILL_CODE.TEST)
    { }
}

[Serializable]
public class Pants : Equipment
{
    public float defense;

    public Pants(ITEM_CODE code, SET_SKILL_CODE set_Code) : base(code, EQUIPPARTS.PANTS, set_Code)
    { }
}

[Serializable]
public class Pants_Amon : Pants
{

    public Pants_Amon():base(ITEM_CODE.PANTS_Amon, SET_SKILL_CODE.TEST)
    { }
}

[Serializable]
public class Neck : Equipment
{

    public float defense;

    public Neck(ITEM_CODE code, SET_SKILL_CODE set_Code) : base(code, EQUIPPARTS.NECK, set_Code)
    { }
}

[Serializable]
public class Neck_Belial : Neck
{
    public Neck_Belial():base(ITEM_CODE.NECK_Belial, SET_SKILL_CODE.TEST)
    { }
}

[Serializable]
public class Belt : Equipment
{
    public float defense;

    public Belt(ITEM_CODE code, SET_SKILL_CODE set_Code) : base(code, EQUIPPARTS.BELT, set_Code)
    { }
}

[Serializable]
public class Belt_Abadon : Belt
{
    public Belt_Abadon() : base(ITEM_CODE.BELT_Abadon, SET_SKILL_CODE.TEST)
    { }
}

[Serializable]
public class Shoes : Equipment
{
    public float defense;

    public Shoes(ITEM_CODE code, SET_SKILL_CODE set_Code) : base(code, EQUIPPARTS.SHOES, set_Code)
    { }
}

[Serializable]
public class Shoes_Baal : Shoes
{
    public Shoes_Baal() : base(ITEM_CODE.SHOES_Baal, SET_SKILL_CODE.TEST)
    { }
}

//////////////////////소모품

public class Consumables : Item
{

    public bool isConsum;

    public Consumables(String name, ITEM_CODE code, GRADE grade, String Exp) : base(name, code, grade, KIND.CONSUMABLES, Exp)
    {

    }

    public Consumables(ITEM_CODE code) : base(code, KIND.CONSUMABLES)
    {
    
    }
}




///////////////////////////재료




////////////////////////////////아바타
public class Avatar: Item
{
    public Avatar_Part_CODE part;
    public Avatar_Group_Base avatar;

    public Avatar(ITEM_CODE code, Avatar_Part_CODE part):base(code, KIND.AVATAR)
    {
        this.part = part;
    }
}

public class Avatar_Coat : Avatar
{
    public Avatar_Coat_CODE avatar_Code;

    public Avatar_Coat(Avatar_Coat_CODE code) : base(ITEM_CODE.AVATAR_COAT, Avatar_Part_CODE.COAT)
    {
        avatar_Code = code;
    }
}

public class Avatar_Coat_Test : Avatar_Coat
{

    public Avatar_Coat_Test() :base(Avatar_Coat_CODE.TEST)
    { }
}

public class Avatar_Pants : Avatar
{
    public Avatar_Pants_CODE avatar_Code;

    public Avatar_Pants(Avatar_Pants_CODE code) : base(ITEM_CODE.AVATAR_PANTS, Avatar_Part_CODE.PANTS)
    {
        avatar_Code = code;
    }
}

public class Avatar_Pants_Test : Avatar_Pants
{

    public Avatar_Pants_Test() : base(Avatar_Pants_CODE.TEST)
    { }
}

public class Avatar_Cap : Avatar
{
    public Avatar_Cap_CODE avatar_Code;

    public Avatar_Cap(Avatar_Cap_CODE code) : base(ITEM_CODE.AVATAR_CAP, Avatar_Part_CODE.CAP)
    {
        avatar_Code = code;
    }
}

public class Avatar_Cap_Test : Avatar_Cap
{

    public Avatar_Cap_Test() : base(Avatar_Cap_CODE.TEST)
    { }
}

public class Avatar_Hair : Avatar
{
    public Avatar_Hair_CODE avatar_Code;

    public Avatar_Hair(Avatar_Hair_CODE code) : base(ITEM_CODE.AVATAR_HAIR, Avatar_Part_CODE.HAIR)
    {
        avatar_Code = code;
    }
}

public class Avatar_Hair_Test : Avatar_Hair
{

    public Avatar_Hair_Test() : base(Avatar_Hair_CODE.TEST)
    { }
}
public class Avatar_Face : Avatar
{
    public Avatar_Face_CODE avatar_Code;

    public Avatar_Face(Avatar_Face_CODE code) : base(ITEM_CODE.AVATAR_FACE, Avatar_Part_CODE.FACE)
    {
        avatar_Code = code;
    }
}

public class Avatar_Face_Test : Avatar_Face
{

    public Avatar_Face_Test() : base(Avatar_Face_CODE.TEST)
    { }
}

public class Avatar_Neck : Avatar
{
    public Avatar_Neck_CODE avatar_Code;

    public Avatar_Neck(Avatar_Neck_CODE code) : base(ITEM_CODE.AVATAR_NECK, Avatar_Part_CODE.NECK)
    {
        avatar_Code = code;
    }
}
public class Avatar_Neck_Test : Avatar_Neck
{

    public Avatar_Neck_Test() : base(Avatar_Neck_CODE.TEST)
    { }
}

public class Avatar_Belt : Avatar
{
    public Avatar_Belt_CODE avatar_Code;

    public Avatar_Belt(Avatar_Belt_CODE code) : base(ITEM_CODE.AVATAR_BELT, Avatar_Part_CODE.BELT)
    {
        avatar_Code = code;
    }
}
public class Avatar_Belt_Test : Avatar_Belt
{

    public Avatar_Belt_Test() : base(Avatar_Belt_CODE.TEST)
    { }
}

public class Avatar_Shoes : Avatar
{
    public Avatar_Shoes_CODE avatar_Code;

    public Avatar_Shoes(Avatar_Shoes_CODE code) : base(ITEM_CODE.AVATAR_SHOES, Avatar_Part_CODE.SHOES)
    {
        avatar_Code = code;
    }
}
public class Avatar_Shoes_Test : Avatar_Shoes
{

    public Avatar_Shoes_Test() : base(Avatar_Shoes_CODE.TEST)
    { }
}

public class Avatar_Body : Avatar
{
    public Avatar_Body_CODE avatar_Code;

    public Avatar_Body(Avatar_Body_CODE code) : base(ITEM_CODE.AVATAR_BODY, Avatar_Part_CODE.BODY)
    {
        avatar_Code = code;
    }
}


//////////////////////////////////////////////////////// 끝

public class Item_Data_MGR : MonoBehaviour    // 1xx - Coat  / 2xx - Pants / 3xx - Neck / 4xx - Belt / 5xx - Shoes / 6xx - Consume / 7xx - Material 
{
    public static Item_Data_MGR instance;

    Dictionary<ITEM_CODE, Coat> CoatsDic;
    Dictionary<ITEM_CODE, Pants> PantsDic;
    Dictionary<ITEM_CODE, Neck> NecksDic;
    Dictionary<ITEM_CODE, Belt> BeltsDic;
    Dictionary<ITEM_CODE, Shoes> ShoesDic;

    public Dictionary<Avatar_Coat_CODE, Avatar_Coat> Avatar_CoatsDic;
    Dictionary<Avatar_Pants_CODE, Avatar_Pants> Avatar_PantsDic;
    Dictionary<Avatar_Cap_CODE, Avatar_Cap> Avatar_CapsDic;
    Dictionary<Avatar_Hair_CODE, Avatar_Hair> Avatar_HairsDic;
    Dictionary<Avatar_Face_CODE, Avatar_Face> Avatar_FacesDic;
    Dictionary<Avatar_Neck_CODE, Avatar_Neck> Avatar_NecksDic;
    Dictionary<Avatar_Belt_CODE, Avatar_Belt> Avatar_BeltsDic;
    Dictionary<Avatar_Shoes_CODE, Avatar_Shoes> Avatar_ShoesDic;
    Dictionary<Avatar_Body_CODE, Avatar_Body> Avatar_BodysDic;

    public Item None;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            CoatsDic = new Dictionary<ITEM_CODE, Coat>();
            PantsDic = new Dictionary<ITEM_CODE, Pants>();
            NecksDic = new Dictionary<ITEM_CODE, Neck>();
            BeltsDic = new Dictionary<ITEM_CODE, Belt>();
            ShoesDic = new Dictionary<ITEM_CODE, Shoes>();

            Avatar_CoatsDic = new Dictionary<Avatar_Coat_CODE, Avatar_Coat>();
            Avatar_PantsDic = new Dictionary<Avatar_Pants_CODE, Avatar_Pants>();
            Avatar_CapsDic = new Dictionary<Avatar_Cap_CODE, Avatar_Cap>();
            Avatar_HairsDic = new Dictionary<Avatar_Hair_CODE, Avatar_Hair>();
            Avatar_FacesDic = new Dictionary<Avatar_Face_CODE, Avatar_Face>();
            Avatar_NecksDic = new Dictionary<Avatar_Neck_CODE, Avatar_Neck>();
            Avatar_BeltsDic = new Dictionary<Avatar_Belt_CODE, Avatar_Belt>();
            Avatar_ShoesDic = new Dictionary<Avatar_Shoes_CODE, Avatar_Shoes>();
            Avatar_BodysDic = new Dictionary<Avatar_Body_CODE, Avatar_Body>();

            Set_ItemInfo();

        }


        
    }


    void Set_ItemInfo()
    {
        Set_CoatInfo();
        
        Set_PantsInfo();
        Set_NeckInfo();
        Set_BeltInfo();
        Set_ShoesInfo();
        



        Set_Avatar_CoatInfo();
        Set_Avatar_BeltInfo();
        Set_Avatar_CapInfo();
        Set_Avatar_FaceInfo();
        Set_Avatar_HairInfo();
        Set_Avatar_NeckInfo();
        Set_Avatar_PantsInfo();
        Set_Avatar_ShoesInfo();
    }

    void Set_CoatInfo()
    {
        CoatsDic.Add(ITEM_CODE.COAT_Satan, new Coat_Satan()); //상의 아이템 클래스 Dictionary에 추가

        CoatsDic[ITEM_CODE.COAT_Satan].set_Code = SET_SKILL_CODE.TEST; //일단 테스트용으로 직접 추가 추후 CSV에 추가

        Dictionary<ITEM_CODE, Dictionary<string, string>> data = CSVReader_ITEM.Read("Item_Data/Coat_Data");  //CSV에서 정보 읽어와서 Dictionary로 변환하는 함수

        foreach(KeyValuePair<ITEM_CODE,Coat> item in CoatsDic)  //Dictionary안에 있는 아이템의 정보를 CSV에서 읽어와서 입력
        {
            int tempGrade;
            float tempDefense;
            
            //디버그
            if (!int.TryParse(data[item.Key]["Grade"], out tempGrade))
            {
                Debug.LogWarning("등급 정수형으로 바꾸지 못 함");
            }

            if (!float.TryParse(data[item.Key]["Defense"], out tempDefense))
            {
                Debug.LogWarning("방어력 실수로 바꾸지 못 함");
            }

            CoatsDic[item.Key].Name = data[item.Key]["Name"];
            CoatsDic[item.Key].Grade = (Item.GRADE) tempGrade;
            CoatsDic[item.Key].defense = tempDefense;
            CoatsDic[item.Key].Icon = Resources.Load<Sprite>(data[item.Key]["Icon"]);
            CoatsDic[item.Key].Explanation = data[item.Key]["Explanation"];
            CoatsDic[item.Key].DropSprite = Resources.Load<Sprite>(data[item.Key]["DropSprite"]);
        }
    }

    void Set_PantsInfo()
    {
        PantsDic.Add(ITEM_CODE.PANTS_Amon, new Pants_Amon());

        PantsDic[ITEM_CODE.PANTS_Amon].set_Code = SET_SKILL_CODE.TEST;


        Dictionary<ITEM_CODE, Dictionary<string, string>> data = CSVReader_ITEM.Read("Item_Data/Pants_Data");

        foreach (KeyValuePair<ITEM_CODE, Pants> item in PantsDic)
        {
            int tempGrade;
            float tempDefense;

            //디버그
            if (!int.TryParse(data[item.Key]["Grade"], out tempGrade))
            {
                Debug.LogWarning("등급 정수형으로 바꾸지 못 함");
            }

            if (!float.TryParse(data[item.Key]["Defense"], out tempDefense))
            {
                Debug.LogWarning("방어력 실수로 바꾸지 못 함");
            }

            PantsDic[item.Key].Name = data[item.Key]["Name"];
            PantsDic[item.Key].Grade = (Item.GRADE)tempGrade;
            PantsDic[item.Key].defense = tempDefense;
            PantsDic[item.Key].Icon = Resources.Load<Sprite>(data[item.Key]["Icon"]);
            PantsDic[item.Key].Explanation = data[item.Key]["Explanation"];
            PantsDic[item.Key].DropSprite = Resources.Load<Sprite>(data[item.Key]["DropSprite"]);
        }
    }

    void Set_NeckInfo()
    {
        NecksDic.Add(ITEM_CODE.NECK_Belial, new Neck_Belial());

        NecksDic[ITEM_CODE.NECK_Belial].set_Code = SET_SKILL_CODE.TEST;

        Dictionary<ITEM_CODE, Dictionary<string, string>> data = CSVReader_ITEM.Read("Item_Data/Neck_Data");

        foreach (KeyValuePair<ITEM_CODE, Neck> item in NecksDic)
        {
            int tempGrade;
            float tempDefense;

            //디버그
            if (!int.TryParse(data[item.Key]["Grade"], out tempGrade))
            {
                Debug.LogWarning("등급 정수형으로 바꾸지 못 함");
            }

            if (!float.TryParse(data[item.Key]["Defense"], out tempDefense))
            {
                Debug.LogWarning("방어력 실수로 바꾸지 못 함");
            }

            NecksDic[item.Key].Name = data[item.Key]["Name"];
            NecksDic[item.Key].Grade = (Item.GRADE)tempGrade;
            NecksDic[item.Key].defense = tempDefense;
            NecksDic[item.Key].Icon = Resources.Load<Sprite>(data[item.Key]["Icon"]);
            NecksDic[item.Key].Explanation = data[item.Key]["Explanation"];
            NecksDic[item.Key].DropSprite = Resources.Load<Sprite>(data[item.Key]["DropSprite"]);
        }
    }

    void Set_BeltInfo()
    {
        BeltsDic.Add(ITEM_CODE.BELT_Abadon, new Belt_Abadon());

        BeltsDic[ITEM_CODE.BELT_Abadon].set_Code = SET_SKILL_CODE.TEST;

        Dictionary<ITEM_CODE, Dictionary<string, string>> data = CSVReader_ITEM.Read("Item_Data/Belt_Data");

        foreach (KeyValuePair<ITEM_CODE, Belt> item in BeltsDic)
        {
            int tempGrade;
            float tempDefense;

            //디버그
            if (!int.TryParse(data[item.Key]["Grade"], out tempGrade))
            {
                Debug.LogWarning("등급 정수형으로 바꾸지 못 함");
            }

            if (!float.TryParse(data[item.Key]["Defense"], out tempDefense))
            {
                Debug.LogWarning("방어력 실수로 바꾸지 못 함");
            }

            BeltsDic[item.Key].Name = data[item.Key]["Name"];
            BeltsDic[item.Key].Grade = (Item.GRADE)tempGrade;
            BeltsDic[item.Key].defense = tempDefense;
            BeltsDic[item.Key].Icon = Resources.Load<Sprite>(data[item.Key]["Icon"]);
            BeltsDic[item.Key].Explanation = data[item.Key]["Explanation"];
            BeltsDic[item.Key].DropSprite = Resources.Load<Sprite>(data[item.Key]["DropSprite"]);
        }
    }

    void Set_ShoesInfo()
    {
        ShoesDic.Add(ITEM_CODE.SHOES_Baal, new Shoes_Baal());

        ShoesDic[ITEM_CODE.SHOES_Baal].set_Code = SET_SKILL_CODE.TEST;

        Dictionary<ITEM_CODE, Dictionary<string, string>> data = CSVReader_ITEM.Read("Item_Data/Shoes_Data");

        foreach (KeyValuePair<ITEM_CODE, Shoes> item in ShoesDic)
        {
            int tempGrade;
            float tempDefense;

            //디버그
            if (!int.TryParse(data[item.Key]["Grade"], out tempGrade))
            {
                Debug.LogWarning("등급 정수형으로 바꾸지 못 함");
            }

            if (!float.TryParse(data[item.Key]["Defense"], out tempDefense))
            {
                Debug.LogWarning("방어력 실수로 바꾸지 못 함");
            }

            ShoesDic[item.Key].Name = data[item.Key]["Name"];
            ShoesDic[item.Key].Grade = (Item.GRADE)tempGrade;
            ShoesDic[item.Key].defense = tempDefense;
            ShoesDic[item.Key].Icon = Resources.Load<Sprite>(data[item.Key]["Icon"]);
            ShoesDic[item.Key].Explanation = data[item.Key]["Explanation"];
            ShoesDic[item.Key].DropSprite = Resources.Load<Sprite>(data[item.Key]["DropSprite"]);
        }
    }


    ////////////아바타 아이템들은 일단 임시로 코드를 짠다.
    void Set_Avatar_CoatInfo()
    {
        Avatar_CoatsDic.Add(Avatar_Coat_CODE.TEST, new Avatar_Coat_Test());

        Avatar_CoatsDic[Avatar_Coat_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Coat/Coat_18300").GetComponent<Avatar_Group_Base>();
        Avatar_CoatsDic[Avatar_Coat_CODE.TEST].Icon = Avatar_CoatsDic[Avatar_Coat_CODE.TEST].avatar.Icon;
    }

    void Set_Avatar_PantsInfo()
    {
        Avatar_PantsDic.Add(Avatar_Pants_CODE.TEST, new Avatar_Pants_Test());

        Avatar_PantsDic[Avatar_Pants_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Pants/Pants_16900").GetComponent<Avatar_Group_Base>();
        Avatar_PantsDic[Avatar_Pants_CODE.TEST].Icon = Avatar_PantsDic[Avatar_Pants_CODE.TEST].avatar.Icon;
    }
    void Set_Avatar_CapInfo()
    {
        Avatar_CapsDic.Add(Avatar_Cap_CODE.TEST, new Avatar_Cap_Test());

        Avatar_CapsDic[Avatar_Cap_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Cap/Cap_17400").GetComponent<Avatar_Group_Base>();
        Avatar_CapsDic[Avatar_Cap_CODE.TEST].Icon = Avatar_CapsDic[Avatar_Cap_CODE.TEST].avatar.Icon;
    }
    void Set_Avatar_HairInfo()
    {
        Avatar_HairsDic.Add(Avatar_Hair_CODE.TEST, new Avatar_Hair_Test());

        Avatar_HairsDic[Avatar_Hair_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Hair/Hair_16400").GetComponent<Avatar_Group_Base>();
        Avatar_HairsDic[Avatar_Hair_CODE.TEST].Icon = Avatar_HairsDic[Avatar_Hair_CODE.TEST].avatar.Icon;
    }
    void Set_Avatar_FaceInfo()
    {
        Avatar_FacesDic.Add(Avatar_Face_CODE.TEST, new Avatar_Face_Test());

        Avatar_FacesDic[Avatar_Face_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Face/Face_15100").GetComponent<Avatar_Group_Base>();
        Avatar_FacesDic[Avatar_Face_CODE.TEST].Icon = Avatar_FacesDic[Avatar_Face_CODE.TEST].avatar.Icon;
    }
    void Set_Avatar_NeckInfo()
    {
        Avatar_NecksDic.Add(Avatar_Neck_CODE.TEST, new Avatar_Neck_Test());

        Avatar_NecksDic[Avatar_Neck_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Neck/Neck_15400").GetComponent<Avatar_Group_Base>();
        Avatar_NecksDic[Avatar_Neck_CODE.TEST].Icon = Avatar_NecksDic[Avatar_Neck_CODE.TEST].avatar.Icon;
    }
    void Set_Avatar_BeltInfo()
    {
        Avatar_BeltsDic.Add(Avatar_Belt_CODE.TEST, new Avatar_Belt_Test());

        Avatar_BeltsDic[Avatar_Belt_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Belt/Belt_13900").GetComponent<Avatar_Group_Base>();
        Avatar_BeltsDic[Avatar_Belt_CODE.TEST].Icon = Avatar_BeltsDic[Avatar_Belt_CODE.TEST].avatar.Icon;
    }
    void Set_Avatar_ShoesInfo()
    {
        Avatar_ShoesDic.Add(Avatar_Shoes_CODE.TEST, new Avatar_Shoes_Test());

        Avatar_ShoesDic[Avatar_Shoes_CODE.TEST].avatar = Resources.Load<GameObject>("Avatar/SwordMan/Shoes/Shoes_16400").GetComponent<Avatar_Group_Base>();
        Avatar_ShoesDic[Avatar_Shoes_CODE.TEST].Icon = Avatar_ShoesDic[Avatar_Shoes_CODE.TEST].avatar.Icon;
    }


    public Item SearchItem(ITEM_CODE code)
    {
        int idx;
        idx = (int)code;
        idx = idx / 100;
        
        switch(idx)
        {
            case 1:
                return CoatsDic[code];

            case 2:
                return PantsDic[code];

            case 3:
                return NecksDic[code];

            case 4:
                return BeltsDic[code];

            case 5:
                return ShoesDic[code];

        }

        return None;
    }


    public Item SearchItem(Avatar_Coat_CODE code)
    {
        return Avatar_CoatsDic[code];
    }

    public Item SearchItem(Avatar_Pants_CODE code)
    {
        return Avatar_PantsDic[code];
    }
    public Item SearchItem(Avatar_Hair_CODE code)
    {
        return Avatar_HairsDic[code];
    }
    public Item SearchItem(Avatar_Cap_CODE code)
    {
        return Avatar_CapsDic[code];
    }
    public Item SearchItem(Avatar_Neck_CODE code)
    {
        return Avatar_NecksDic[code];
    }
    public Item SearchItem(Avatar_Belt_CODE code)
    {
        return Avatar_BeltsDic[code];
    }
    public Item SearchItem(Avatar_Face_CODE code)
    {
        return Avatar_FacesDic[code];
    }
    public Item SearchItem(Avatar_Shoes_CODE code)
    {
        return Avatar_ShoesDic[code];
    }
}



public enum ITEM_CODE // 1xx - Coat  / 2xx - Pants / 3xx - Neck / 4xx - Belt / 5xx - Shoes / 6xx - Consume / 7xx - Material                    
{
    NONE = 0,
    COAT_Satan = 101,
    PANTS_Amon = 201,
    NECK_Belial = 301,
    BELT_Abadon = 401,
    SHOES_Baal = 501,
    AVATAR_COAT = 1000,
    AVATAR_PANTS = 1010,
    AVATAR_CAP = 1020,
    AVATAR_HAIR = 1030,
    AVATAR_FACE = 1040,
    AVATAR_NECK = 1050,
    AVATAR_BELT = 1060,
    AVATAR_SHOES = 1070,
    AVATAR_BODY = 1080,
    AVATAR_WEAPON = 1090,
}