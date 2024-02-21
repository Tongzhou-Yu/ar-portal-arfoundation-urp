using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortableObject : MonoBehaviour
{
    public int m_layer;
    private Boolean m_isExited = false;
    private Boolean m_isFirstTime = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Portal")
        {
            if (!m_isExited)
            {
                if (!m_isFirstTime)
                {
                    this.gameObject.layer = 0;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Portal")
        {
            if (!m_isExited)
            {
                if (!m_isFirstTime)
                {
                    m_isExited = true;
                    m_isFirstTime = true;
                }

            }
            else
            {
                if (m_isFirstTime)
                {
                    this.gameObject.layer = m_layer;
                    m_isExited = false;
                    m_isFirstTime = false;
                }

            }
        }
    }
}
