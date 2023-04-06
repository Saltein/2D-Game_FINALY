using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LegScriptForAnotherLeg : MonoBehaviour
{
    private float moveX;
    private float moveY;

    float scale;

    private void Update()
    {
        float angle = Mathf.Atan2(moveY, moveX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            scale = -LegScript.scale;
        }
        else { scale = 0.5f; }


        transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z); // изменяем размер спрайта по оси Y
    }
}