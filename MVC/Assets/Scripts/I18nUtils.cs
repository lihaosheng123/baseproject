using UnityEngine;
public static class I18nUtils
{
    private const string I18N_PREFS_KEY = "I18n";
    private const string I18NNeedFirstSetting = "I18NNeedFirstSetting";
    public const string LANGUAGE_CN = "cn";
    public const string LANGUAGE_EN = "en";

    private static string i18nPrefs;
    public static string I18nPrefs
    {
        get
        {
            if (string.IsNullOrEmpty(i18nPrefs))
            {
                i18nPrefs = PlayerPrefs.GetString(I18N_PREFS_KEY, LANGUAGE_CN);
            }
            return i18nPrefs;
        }
        set
        {
            PlayerPrefs.SetString(I18N_PREFS_KEY, value);
            i18nPrefs = value;
        }
    }

    public static bool NeedSetLanguageFirstTime
    {
        get { return PlayerPrefs.GetInt(I18NNeedFirstSetting, 1) == 1; }
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt(I18NNeedFirstSetting, 1);
            }
            else
            {
                PlayerPrefs.SetInt(I18NNeedFirstSetting, 0);
            }
        }
    }

    /// <summary>
    /// 当前语言
    /// </summary>
    public static string ToLanguage(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;

        languageConfig data = languageConfigManager.Instance.GetDataByID(str);
        if (data == null)
            return str;

        if (I18nPrefs == LANGUAGE_CN)
        {
            return data.cn;
        }
        if (I18nPrefs == LANGUAGE_EN)
        {
            return data.en;
        }
        return str;
    }
}
