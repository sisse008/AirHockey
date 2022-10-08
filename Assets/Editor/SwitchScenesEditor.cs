#if  UNITY_EDITOR


using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Linq;


[InitializeOnLoad]
public class SwitchScenesEditor 
{
    [MenuItem("MyUtilities/Change Scene/Menu Scene")]
    public static void SwitchToMenuScene()
    {
        SwitchSceneInEditor(0);
    }
    [MenuItem("MyUtilities/Change Scene/SelectionScene")]
    public static void SwitchToSelectionScene()
    {
        SwitchSceneInEditor(1);
    }

    [MenuItem("MyUtilities/Change Scene/Game Scene")]
    public static void SwitchToMainScene()
    {
        SwitchSceneInEditor(2);
    }

    private static bool IsCurrectKeysToSwitchScenesInEditor()
    {
        if (EditorInputListener.currentNumberPressed != -1 
            && EditorInputListener.currentNumberPressed < SceneManager.sceneCountInBuildSettings - 1)
            return true;
        return false;
    }


    static void SwitchSceneInEditor(int num)
    {
        if (num >= SceneManager.sceneCountInBuildSettings)
            return;
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(num));
        }
    }
}
#endif
