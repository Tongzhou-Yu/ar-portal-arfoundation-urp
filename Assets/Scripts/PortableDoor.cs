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
                m_innerworld.layer = m_OutWorldLayer;
                foreach (Transform child in m_innerworld.transform)
                {
                    child.gameObject.layer = m_OutWorldLayer;
                }

            }
            else
            {
                m_innerworld.layer = m_InWorldLayer;
                foreach (Transform child in m_innerworld.transform)
                {
                    child.gameObject.layer = m_InWorldLayer;
                }
            }
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
