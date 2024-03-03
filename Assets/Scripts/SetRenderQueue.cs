using UnityEngine;

public class SetRenderQueue : MonoBehaviour
{
    [SerializeField]
    protected int[] m_queues = new int[] { 2000 };

    protected void Awake()
    {
        SetVals();
    }

    private void OnValidate()
    {
        SetVals();
    }

    private void SetVals()
    {
        Material[] materials = GetComponent<Renderer>().sharedMaterials;
        for (int i = 0; i < materials.Length && i < m_queues.Length; ++i)
        {
            materials[i].renderQueue = m_queues[i];
        }
    }
}