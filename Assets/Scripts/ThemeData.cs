using UnityEngine;



[System.Serializable]
public struct ThemeZone
{
	public int length;
    public GameObject[] prefabList;
}


[CreateAssetMenu(fileName ="themeData", menuName ="Trash Dash/Theme Data")]
public class ThemeData : ScriptableObject
{
    [Header("Theme Data")]
    public string themeName;
    
    [Header("Objects")]
    public ThemeZone[] zone;
}
