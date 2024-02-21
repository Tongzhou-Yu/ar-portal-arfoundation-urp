using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PO_Sway : MonoBehaviour
{
    // 保存物体的原始位置
    private Vector3 originalPosition;

    void Start()
    {
        // 在开始时获取物体的原始位置
        originalPosition = transform.position;
    }

    void Update()
    {
        // 设置移动的速度和范围
        float speed = 2f;
        float maxDistance = 3.5f;

        // 使用Mathf.PingPong函数来创建一个在0和maxDistance之间来回变化的值
        float movement = Mathf.PingPong(Time.time * speed, maxDistance);

        // 将这个值加上原始位置，然后应用到物体的位置上，使其在x轴上来回移动
        transform.position = originalPosition - new Vector3(0, 0, movement);
    }
}
