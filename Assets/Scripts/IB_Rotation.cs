using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IB_Rotation : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(Vector3.up * 60.0f * Time.deltaTime);
    }
}
