
//-----------------------------------------------
//              生成代码不要修改
//-----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfigManager
{
    private static void Deserialize(DynamicPacket dynamicPacket)
    {
        languageConfigManager.Instance.Deserialize(dynamicPacket);
        testConfigManager.Instance.Deserialize(dynamicPacket);
    }
    
    public static void LoadConfig(string Configdatapath)
    {
        FileStream fileStream = new FileStream(Configdatapath, FileMode.Open, FileAccess.Read);
        BinaryReader binaryReader = new BinaryReader(fileStream);
        int cnt = binaryReader.ReadInt32();
        byte[] bytes = binaryReader.ReadBytes(cnt);
        DynamicPacket dynamicPacket = new DynamicPacket(bytes);
        Deserialize(dynamicPacket);
        binaryReader.Close();
        fileStream.Close();
    }
}
