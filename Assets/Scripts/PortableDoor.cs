using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.Rendering.Universal;

public class PortableDoor : MonoBehaviour
{
    public GameObject m_innerworld;
    public int m_InWorldLayer;
    public int m_OutWorldLayer;
    private Boolean m_isEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            if (!m_isEntered)
            {
                Debug.Log("Player entered the door");
                SetLayerRecursively(m_innerworld.transform, m_OutWorldLayer);
            }
            else
            {
                SetLayerRecursively(m_innerworld.transform, m_InWorldLayer);
            }
        }
    }
    void SetLayerRecursively(Transform parent, int layer)
    {
        parent.gameObject.layer = layer;

        foreach (Transform child in parent)
        {
            SetLayerRecursively(child, layer);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            if (!m_isEntered)
            {
                Debug.Log("Player exited the door");
                m_isEntered = true;
            }
            else
            {
                m_isEntered = false;
            }
        }

    }
}
