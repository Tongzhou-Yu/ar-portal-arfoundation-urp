using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider m_slider; // 指向Slider的引用
    private Material m_material; // 指向Material的引用

    void Start()
    {
        m_material = this.GetComponent<MeshRenderer>().material;
        // 设置Slider的最小值和最大值
        m_slider.minValue = -7;
        m_slider.maxValue = 5;

        // 添加Slider的值改变事件的处理方法
        m_slider.onValueChanged.AddListener(UpdateMaterialDistance);
    }

    void UpdateMaterialDistance(float value)
    {
        // 更新Material的distance变量
        m_material.SetFloat("_Distance", value);
    }
}