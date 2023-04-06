using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LegScript : MonoBehaviour
{
    public static float speed = 5f; // скорость изменения размера
    float minYScale = -1f; // минимальный размер по оси Y
    float maxYScale = 1f; // максимальный размер по оси Y

    float direction = 1f; // направление изменения размера

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
            if (scale < minYScale || scale > maxYScale) // если достигли границ размеров
            {
                direction *= -1f; // меняем направление изменения размера
                scale = Mathf.Clamp(scale, minYScale, maxYScale); // устанавливаем границы размеров
            }
        }
        else { scale = 0.5f; }


        transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z); // изменяем размер спрайта по оси Y
    }
}