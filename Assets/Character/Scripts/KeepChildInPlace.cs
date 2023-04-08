using UnityEngine;

public class KeepChildInPlace : MonoBehaviour
{
    private Transform parentTransform;
    private Transform otherTransform;

    private void Start()
    {
        otherTransform = GameObject.FindWithTag("grass").transform;
        parentTransform = transform.parent.transform;
    }

    private void LateUpdate()
    {
        // ��������� ��������������� ���� �������� � ��������� �������
        transform.rotation = otherTransform.rotation;
    }
}
