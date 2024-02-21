using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IB_Rotation : MonoBehaviour
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        this.transform.Rotate(Vector3.up * 60.0f * Time.deltaTime);
    }
}
