using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DomeTransition : MonoBehaviour
{
    public List<Texture2D> textures; // 存储Texture2D的列表
    public Button switchButton; // 切换按钮
    public InputField inputField; // 输入框
    public float initialTransitionSpeed = 0.001f; // 初始速度
    public float acceleration = 0.0001f; // 加速度
    private float transitionSpeed; // 当前速度
    public float maximumTransitionSpeed = 0.1f; // 最大速度
    public float minimumTransitionSpeed = 0.01f; // 最小速度
    private int currentTextureIndex = 0; // 当前使用的Texture2D的索引
    private Material material; // 当前物体的Material
    private bool isSwitching = false; // 是否正在切换Texture

    void Start()
    {
        // 获取当前物体的Material
        material = GetComponent<Renderer>().material;

        // 添加按钮的点击事件的处理方法
        switchButton.onClick.AddListener(() =>
        {
            if (!isSwitching)
            {
                StartCoroutine(SwitchTextureCoroutine());
            }
        });

        // 设置初始的Texture和速度
        transitionSpeed = initialTransitionSpeed;
        SetTexture();

        // 在场景开始时，将Distance从5逐步递减到-7
        StartCoroutine(InitialTransitionCoroutine());
    }

    IEnumerator InitialTransitionCoroutine()
    {
        isSwitching = true;
        switchButton.interactable = false; // 禁用按钮

        // 从5逐步递减到-7
        for (float distance = 5; distance >= -7; distance -= transitionSpeed)
        {
            material.SetFloat("_Distance", distance);
            if (transitionSpeed < maximumTransitionSpeed)
            {
                transitionSpeed += acceleration; // 加速
            }
            yield return null; // 等待下一帧
        }

        isSwitching = false;
        switchButton.interactable = true; // 启用按钮
    }

    IEnumerator SwitchTextureCoroutine()
    {
        isSwitching = true;
        switchButton.interactable = false; // 禁用按钮

        // 从-7逐步递加到5
        for (float distance = -7; distance <= 5; distance += transitionSpeed)
        {
            material.SetFloat("_Distance", distance);
            if (transitionSpeed > minimumTransitionSpeed)
            {
                transitionSpeed -= acceleration; // 减速
            }
            yield return null; // 等待下一帧
        }

        // 切换到下一个Texture
        currentTextureIndex = (currentTextureIndex + 1) % textures.Count;
        transitionSpeed = initialTransitionSpeed; // 重置速度
        SetTexture();

        // 从5逐步递减到-7
        for (float distance = 5; distance >= -7; distance -= transitionSpeed)
        {
            material.SetFloat("_Distance", distance);
            if (transitionSpeed < maximumTransitionSpeed)
            {
                transitionSpeed += acceleration; // 加速
            }
            yield return null; // 等待下一帧
        }

        isSwitching = false;
        switchButton.interactable = true; // 启用按钮
    }

    void SetTexture()
    {
        // 设置Material的Skybox Texture
        material.SetTexture("_Skybox_Texture", textures[currentTextureIndex]);

        // 设置InputField的Placeholder的text为当前Texture2D的名字
        inputField.placeholder.GetComponent<Text>().text = textures[currentTextureIndex].name;
    }
}