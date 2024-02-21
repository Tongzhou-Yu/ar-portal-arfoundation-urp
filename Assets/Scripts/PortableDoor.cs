using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortableDoor : MonoBehaviour
{
    public GameObject m_innerworld;
    public int m_layer;
    private Boolean m_isEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            if (!m_isEntered)
            {
                Debug.Log("Player entered the door");
                m_innerworld.layer = 0;
                foreach (Transform child in m_innerworld.transform)
                {
                    child.gameObject.layer = 0;
                }

            }
            else
            {
                m_innerworld.layer = m_layer;
                foreach (Transform child in m_innerworld.transform)
                {
                    child.gameObject.layer = m_layer;
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
