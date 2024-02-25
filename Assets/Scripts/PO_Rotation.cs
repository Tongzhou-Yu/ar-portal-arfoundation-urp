using UnityEngine;

public class PO_Rotation : MonoBehaviour
{
    public GameObject target; // 目标GameObject
    public float speed = 25f; // 旋转速度

    public enum Axis
    {
        X, Y, Z
    }

    public Axis rotationAxis = Axis.Z; // 旋转轴

    void Update()
    {
        Vector3 axis = Vector3.up; // 默认为Y轴

        switch (rotationAxis)
        {
            case Axis.X:
                axis = Vector3.right;
                break;
            case Axis.Y:
                axis = Vector3.up;
                break;
            case Axis.Z:
                axis = Vector3.forward;
                break;
        }

        // 让当前GameObject绕着目标GameObject旋转
        transform.RotateAround(target.transform.position, axis, speed * Time.deltaTime);
    }
}