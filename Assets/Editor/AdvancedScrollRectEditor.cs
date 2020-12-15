using UnityEditor;
using UnityEngine;

namespace Editor
{
   [CustomEditor(typeof(AdvancedScrollRect))]
   public class AdvancedScrollRectEditor:UnityEditor.UI.ScrollRectEditor
   {
      public override void OnInspectorGUI() 
      {

         AdvancedScrollRect component = (AdvancedScrollRect)target;

         base.OnInspectorGUI();
         component.selectionPoint =
            (Transform)EditorGUILayout.ObjectField("TargetPoint", component.selectionPoint, typeof(Transform));
         component.buttonScale = EditorGUILayout.Slider("ScaleValue", component.buttonScale, 1, 4);
         component.animation = (AdvancedScrollRect.Animation) EditorGUILayout.EnumPopup("Animations", component.animation);
      }
      
      [MenuItem("GameObject/UI/CustomUI/HorizontalScrollRect")]
      public static void AddHorizontalScrollRect()
      {
         GameObject hsr = Instantiate(Resources.Load<GameObject>("CustomUI/HorizontalScrollRect"), Selection.activeGameObject.transform, false);
         hsr.transform.name = "HorizontalScrollRect";
      }
   }
}
