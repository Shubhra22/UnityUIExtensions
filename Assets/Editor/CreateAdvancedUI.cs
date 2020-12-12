using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AdvancedScrollRect))]
public class CreateAdvancedUI:UnityEditor.UI.ScrollRectEditor
{
   public override void OnInspectorGUI() {

      AdvancedScrollRect component = (AdvancedScrollRect)target;

      base.OnInspectorGUI();
      component.selectionPoint =
         (Transform)EditorGUILayout.ObjectField("TargetPoint", component.selectionPoint, typeof(Transform));
      component.buttonScale = EditorGUILayout.Slider("ScaleValue", component.buttonScale, 1, 4);
   }
}
