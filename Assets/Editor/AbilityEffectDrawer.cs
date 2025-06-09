#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using UnityEditorInternal;
using HeroArena;

[CustomPropertyDrawer(typeof(AbilityEffect), true)]
public class AbilityEffectDrawer : PropertyDrawer
{
    // Cache di tutti i tipi concreti di AbilityEffect
    private static readonly Type[] effectTypes =
        TypeCache.GetTypesDerivedFrom<AbilityEffect>()
                 .Where(t => !t.IsAbstract)
                 .ToArray();

    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        // Se non è un managed reference, disegna normalmente
        if (prop.propertyType != SerializedPropertyType.ManagedReference)
        {
            EditorGUI.PropertyField(pos, prop, label, true);
            return;
        }

        // --- altrimenti: nostra logica custom ---


        // 1) riga del dropdown per tipo / pulsante “Add”
        var line = new Rect(pos.x, pos.y, pos.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.BeginProperty(line, label, prop);

        // se non è ancora istanziato
        if (prop.managedReferenceValue == null)
        {
            if (GUI.Button(line, "Add Fragment ▾", EditorStyles.popup))
                ShowTypeMenu(prop);
            EditorGUI.EndProperty();
            return;
        }

        // altrimenti mostra il nome del tipo corrente
        var currentType = prop.managedReferenceValue.GetType();
        if (GUI.Button(line, currentType.Name + " ▾", EditorStyles.popup))
            ShowTypeMenu(prop);

        EditorGUI.EndProperty();

        // 2) disegna i campi interni del frammento
        var contentRect = new Rect(
            pos.x,
            pos.y + EditorGUIUtility.singleLineHeight + 2,
            pos.width,
            pos.height - EditorGUIUtility.singleLineHeight - 2
        );
        EditorGUI.PropertyField(contentRect, prop, label: GUIContent.none, includeChildren: true);
    }

    private void ShowTypeMenu(SerializedProperty prop)
    {
        var menu = new GenericMenu();
        foreach (var t in effectTypes)
        {
            menu.AddItem(new GUIContent(t.Name), false, () => {
                prop.managedReferenceValue = Activator.CreateInstance(t);
                prop.serializedObject.ApplyModifiedProperties();
            });
        }
        menu.ShowAsContext();
    }

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        // Fallback generico
        if (prop.propertyType != SerializedPropertyType.ManagedReference ||
            prop.managedReferenceValue == null)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        // header + spazio + altezza dei campi interni
        return EditorGUIUtility.singleLineHeight + 2 +
               EditorGUI.GetPropertyHeight(prop, includeChildren: true);
    }
}
#endif
