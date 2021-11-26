using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExcel : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        string configpath = Application.streamingAssetsPath + "/Config/Config.data";
        ConfigManager.LoadConfig(configpath);
		testConfig temp = testConfigManager.Instance.GetDataByID(1);
		if (temp == null)
			return;

		Debug.Log(temp.HasUse.ToString());
		Debug.Log(temp.HP.ToString());
		Debug.Log(temp.name_i18n.ToLanguage());
		Debug.Log(temp.Vec1[0].ToString());
		Debug.Log(temp.Vec2[0].ToString());
		Debug.Log(temp.Vec4[0].ToString());
		Debug.Log(temp.Map1[1].ToString());
		Debug.Log(temp.Map2[2].ToString());
		Debug.Log(temp.Map4[3].ToString());
		Debug.Log(temp.Map5["阿尔萨斯"].ToString());
		Debug.Log(temp.Map6["伊利丹"].ToString());
		Debug.Log(temp.Map8["琵琶行"].ToString());
	}

	// Update is called once per frame
	void Update () {

	}
}
