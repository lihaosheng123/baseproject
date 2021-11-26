
//-----------------------------------------------
//              生成代码不要修改
//-----------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;

public class languageConfig
{
    public string ID;    //		id索引
    public string cn;    //		string
    public string en;    //		string

    public void Deserialize (DynamicPacket packet)
    {
        ID = packet.PackReadString();
        cn = packet.PackReadString();
        en = packet.PackReadString();
    }
}

public class languageConfigManager
{
    private static languageConfigManager mInstance;
    
    public static languageConfigManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new languageConfigManager();
            }
            
            return mInstance;
        }
    }

    private Dictionary<string, languageConfig> mDict = new Dictionary<string, languageConfig>();
    
    public Dictionary<string, languageConfig> Dict
    {
        get {return mDict;}
    }

    public void Deserialize (DynamicPacket packet)
    {
        int num = (int)packet.PackReadInt32();
        for (int i = 0; i < num; i++)
        {
            languageConfig item = new languageConfig();
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
    
    public List<languageConfig> GetAllData()
    {
        return mDict.Values.ToList();
    }
    
    public languageConfig GetDataByID(string id)
    {
        if(mDict.ContainsKey(id))
        {
            return mDict[id];
        }
        else
        {
            Debug.LogError("languageConfig表格配置错误！错误ID:"+id);
            return null;
        }
    }
}
