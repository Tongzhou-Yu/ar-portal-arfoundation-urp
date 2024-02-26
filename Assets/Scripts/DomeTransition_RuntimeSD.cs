using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class DomeTransition_RuntimeSD : MonoBehaviour
{
    [Header("Dome Transition Settings")]
    public Texture2D m_LogoTexture;
    public RenderTexture m_renderTexture;
    public Button switchButton; // 切换按钮
    public InputField urlInputField; // URL输入框
    public InputField promptInputField; // Prompt输入框
    public float initialTransitionSpeed = 0.01f; // 初始速度
    public float acceleration = 0.0001f; // 加速度
    private float transitionSpeed; // 当前速度
    public float maximumTransitionSpeed = 0.1f; // 最大速度
    public float minimumTransitionSpeed = 0.01f; // 最小速度
    private Material material; // 当前物体的Material
    private bool isSwitching = false; // 是否正在切换Texture
    Coroutine transitionCoroutine; // 切换Texture的协程

    [Header("Stable Diffusion Settings")]
    public string m_lora = "<lora:360Diffusion_v1:1>";
    private string m_url = "http://127.0.0.1:7860";
    public string m_steps = "20";
    public string m_width = "1024";
    public string m_height = "512";
    void Start()
    {
        urlInputField.text = m_url;
        // 获取当前物体的Material
        material = GetComponent<Renderer>().material;
        Graphics.Blit(m_LogoTexture, m_renderTexture);

        // 设置初始速度
        transitionSpeed = initialTransitionSpeed;

        // 添加按钮的点击事件的处理方法
        switchButton.onClick.AddListener(() =>
        {
            if (!isSwitching)
            {
                // 启动TransitionCoroutine协程，并保存它的引用
                transitionCoroutine = StartCoroutine(TransitionCoroutine());
                // 启动SwitchTextureCoroutine协程
                StartCoroutine(SwitchTextureCoroutine());

            }
        });

    }
    IEnumerator SwitchTextureCoroutine()
    {
        isSwitching = true;
        switchButton.interactable = false; // 禁用按钮

        if (urlInputField.text != "")
        {
            // 更新URL
            m_url = urlInputField.text;
        }

        // 发送HTTP请求并获取新的Texture
        string prompt = promptInputField.text;
        yield return StartCoroutine(SendPostRequest(prompt));

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
        transitionSpeed = initialTransitionSpeed; // 重置速度
    }
    IEnumerator TransitionCoroutine()
    {
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

        transitionSpeed = initialTransitionSpeed; // 重置速度
    }
    IEnumerator SendPostRequest(string prompt)
    {
        string url = m_url + "/sdapi/v1/txt2img";

        // Create a payload
        JObject payload = new JObject();
        payload["prompt"] = prompt + "," + m_lora;
        payload["steps"] = m_steps;
        payload["width"] = m_width;
        payload["height"] = m_height;

        // Create a request
        UnityWebRequest www = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(payload.ToString());
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        // Send the request
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Parse the response
            JObject response = JObject.Parse(www.downloadHandler.text);
            string base64Image = response["images"][0].ToString();

            // 等待TransitionCoroutine协程完成
            yield return transitionCoroutine;

            // Convert base64 to Texture2D
            Texture2D texture = new Texture2D(2, 2);
            byte[] imageBytes = System.Convert.FromBase64String(base64Image);
            if (texture.LoadImage(imageBytes))
            {
                // Apply texture to RenderTexture
                Graphics.Blit(texture, m_renderTexture);
            }
        }
        Debug.Log("SendPostRequest");
    }
}