using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Editor
{ 
    public class ProgressBarEditor : UnityEditor.Editor
    {
        [MenuItem("GameObject/UI/CustomUI/Linear Progress Bar")]
        public static void AddLinearProgressBar()
        {
            GameObject bar = Instantiate(Resources.Load<GameObject>("CustomUI/LinearProgressBar"), Selection.activeGameObject.transform, false);
            bar.transform.name = "LinearProgressBar";
        }
        
        [MenuItem("GameObject/UI/CustomUI/Radial Progress Bar")]
        public static void AddRadialProgressBar()
        {
            GameObject bar = Instantiate(Resources.Load<GameObject>("CustomUI/RadialProgressBar"), Selection.activeGameObject.transform, false);
            bar.transform.name = "RadialProgressBar";
        }
    }
}
