using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LegScript : MonoBehaviour
{
    public static float speed = 5f; // �������� ��������� �������
    float minYScale = -1f; // ����������� ������ �� ��� Y
    float maxYScale = 1f; // ������������ ������ �� ��� Y

    float direction = 1f; // ����������� ��������� �������

    private float moveX;    
    private float moveY;

    public static float scale;

    private void Update()
    {
        float angle = Mathf.Atan2(moveY, moveX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            scale = transform.localScale.y + speed * direction * Time.deltaTime;
            if (scale < minYScale || scale > maxYScale) // ���� �������� ������ ��������
            {
                direction *= -1f; // ������ ����������� ��������� �������
                scale = Mathf.Clamp(scale, minYScale, maxYScale); // ������������� ������� ��������
            }
        }
        else { scale = 0.5f; }


        transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z); // �������� ������ ������� �� ��� Y
    }
}