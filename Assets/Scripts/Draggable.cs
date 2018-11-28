using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    enum DraggableType
    {
        Self,
        Prefab,
        Other
    }

    [SerializeField, HideInInspector]
    DraggableType draggableType = DraggableType.Self;

    [SerializeField, HideInInspector]
    Transform dragBody;

    [SerializeField, HideInInspector]
    Transform otherBody;

    Crystal crystal;

    // Use this for initialization
    void Start()
    {
        switch (draggableType)
        {
            case DraggableType.Self:
                dragBody = transform;
                break;

            case DraggableType.Prefab:
                dragBody = otherBody.GetComponentInChildren<Transform>();
                break;

            case DraggableType.Other:
                dragBody = otherBody.GetComponentInChildren<Transform>();
                break;
        }

        if (dragBody == null)
        {
            print("Draggable was unable to find any Rigidbody! Destroying self.");
            Destroy(this);
        }

        crystal = GetComponentInParent<Crystal>();
    }


    public Transform GetDraggable()
    {
        if (draggableType == DraggableType.Prefab)
        {
            Transform otherTransform = Instantiate(otherBody).GetComponentInChildren<Transform>();
            otherTransform.position = transform.position;
            otherTransform.rotation = transform.rotation;

            if (otherTransform)
            {
                //FIXME: This does not belong here
                if (crystal)
                {
                    crystal.Harvest();
                }

                return otherTransform;
            }
            else
            {
                print("Unable to find Rigidbody on Prefab?!");
                return null;
            }
        }
        else if (draggableType == DraggableType.Other)
        {
            Transform otherTransform = otherBody.GetComponentInChildren<Transform>();
            return otherTransform;
        }
        else
        {
            return dragBody;
        }
    }
}


[CustomEditor(typeof(Draggable))]
public class DraggableEditor : Editor
{
    SerializedProperty m_Other;
    SerializedProperty m_DragType;

    protected virtual void OnEnable()
    {
        m_Other = this.serializedObject.FindProperty("otherBody");
        m_DragType = this.serializedObject.FindProperty("draggableType");
    }


    override public void OnInspectorGUI()
    {
        DrawDefaultInspector();
        this.serializedObject.Update();

        GUIContent tooltip = new GUIContent("Draggable Type:", "Which Rigidbody is returned to the grappling attach function?");
        EditorGUILayout.PropertyField(m_DragType, tooltip);

        if (m_DragType.enumValueIndex != 0)
        {
            GUIContent other_tooltip = new GUIContent("Other Body:", "Transform from which to extract a Rigidbody");
            EditorGUILayout.PropertyField(m_Other, other_tooltip);
        }

        this.serializedObject.ApplyModifiedProperties();
    }
}
