using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbilityManager))]
class AbilityManagerEditor : Editor
{
    bool ShowAbilities = true;
    bool ShowAbilitiesToEquip = true;
    bool ShowMisc = true;

    public override void OnInspectorGUI()
    {
        GUIStyle Foldout = new GUIStyle(GUI.skin.label);
        Foldout.richText = true;

        ShowAbilities = EditorGUILayout.Foldout(ShowAbilities, "<b><size=14>Abilities</size></b>", true, Foldout);
        if (ShowAbilities)
        {
            EditorGUI.indentLevel++;
            ShowAbilitiesToEquip = EditorGUILayout.Foldout(ShowAbilitiesToEquip, "<b>Abilities Equipped At Start</b>", true, Foldout);
            if (ShowAbilitiesToEquip)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("SecondarySlot"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Ability1Slot"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Ability2Slot"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("CrucifixionSlot"));
                EditorGUI.indentLevel--;
            }

            ShowMisc = EditorGUILayout.Foldout(ShowMisc, "<b>Misc</b>", true, Foldout);
            if (ShowMisc)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.ObjectField(serializedObject.FindProperty("AbilityData"));
                EditorGUILayout.ObjectField(serializedObject.FindProperty("HUDManager"));
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }
    }
}
