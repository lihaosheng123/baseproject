
//-----------------------------------------------
//              生成代码不要修改
//-----------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;

public class testConfig
{
    public int ID;    //		ID
    public float HP;    //		float类型
    public bool HasUse;    //		bool类型
    public string name_i18n;    //		道具名称
    public string desc_i18n;    //		道具描述
    public List<int> Vec1;    //		int数组
    public List<float> Vec2;    //		float数组
    public List<string> Vec4;    //		string数组
    public Dictionary<int, int> Map1;    //		intint字典
    public Dictionary<int, float> Map2;    //		intfloat字典
    public Dictionary<int, string> Map4;    //		intstring字典
    public Dictionary<string, int> Map5;    //		stringint字典
    public Dictionary<string, float> Map6;    //		stringfloat字典
    public Dictionary<string, string> Map8;    //		stringstring字典

    public void Deserialize (DynamicPacket packet)
    {
        ID = packet.PackReadInt32();
        HP = packet.PackReadFloat();
        HasUse = packet.PackReadBoolean();
        name_i18n = packet.PackReadString();
        desc_i18n = packet.PackReadString();
        Vec1 = SheetGenCommonFunc.GetListInt(packet.PackReadString());
        Vec2 = SheetGenCommonFunc.GetListFloat(packet.PackReadString());
        Vec4 = SheetGenCommonFunc.GetListString(packet.PackReadString());
        Map1 = SheetGenCommonFunc.GetDictIntInt(packet.PackReadString());
        Map2 = SheetGenCommonFunc.GetDictIntFloat(packet.PackReadString());
        Map4 = SheetGenCommonFunc.GetDictIntString(packet.PackReadString());
        Map5 = SheetGenCommonFunc.GetDictStringInt(packet.PackReadString());
        Map6 = SheetGenCommonFunc.GetDictStringFloat(packet.PackReadString());
        Map8 = SheetGenCommonFunc.GetDictStringString(packet.PackReadString());
    }
}

public class testConfigManager
{
    private static testConfigManager mInstance;
    
    public static testConfigManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new testConfigManager();
            }
            
            return mInstance;
        }
    }

    private Dictionary<int, testConfig> mDict = new Dictionary<int, testConfig>();
    
    public Dictionary<int, testConfig> Dict
    {
        get {return mDict;}
    }

    public void Deserialize (DynamicPacket packet)
    {
        int num = (int)packet.PackReadInt32();
        for (int i = 0; i < num; i++)
        {
            testConfig item = new testConfig();
            item.Deserialize(packet);
            if (mDict.ContainsKey(item.ID))
            {
                mDict[item.ID] = item;
            }
            else
            {
                mDict.Add(item.ID, item);
            }
        }
    }
    
    public List<testConfig> GetAllData()
    {
        return mDict.Values.ToList();
    }
    
    public testConfig GetDataByID(int id)
    {
        if(mDict.ContainsKey(id))
        {
            return mDict[id];
        }
        else
        {
            Debug.LogError("testConfig表格配置错误！错误ID:"+id);
            return null;
        }
    }
}
