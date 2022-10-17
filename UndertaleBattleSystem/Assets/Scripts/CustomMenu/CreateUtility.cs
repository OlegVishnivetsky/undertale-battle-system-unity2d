using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class CreateUtility
{
    public static void CreatePrefab(string path)
    {
        GameObject newObject = PrefabUtility.InstantiatePrefab(Resources.Load(path)) as GameObject;
        Place(newObject);
    }

    public static void Place(GameObject gameObject)
    {
        StageUtility.PlaceGameObjectInCurrentStage(gameObject);
        GameObjectUtility.EnsureUniqueNameForSibling(gameObject);

        Undo.RegisterCreatedObjectUndo(gameObject, $"Create Object: {gameObject.name}");
        Selection.activeGameObject = gameObject;

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}