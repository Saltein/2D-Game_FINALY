using UnityEngine;

public class KeepChildInPlace : MonoBehaviour
{
    private Transform parentTransform;
    [SerializeField] private Transform otherTransform;

    private void Start()
    {
        parentTransform = transform.parent.transform;
    }

    private void LateUpdate()
    {
        // ��������� ��������������� ���� �������� � ��������� �������
        transform.rotation = otherTransform.rotation;
    }
}
