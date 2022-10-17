using UnityEditor;

public static class CustomMenuItems
{
    [MenuItem("GameObject/UI/TabbedMenu")]
    public static void CreateTabbedMenu()
    {
        CreateUtility.CreatePrefab("Prefabs/TabMenu");
    }
}