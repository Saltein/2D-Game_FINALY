using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    Light[] lights;
    void Start()
    {
        // Получаем все объекты с компонентом Light
        lights = FindObjectsOfType<Light>();

        // Отключаем только источники света типа Point Light

    }

    private void Update()
    {
        if (Day_Night_Change.timerHours == Day_Night_Change.startDayTime)
        {
            foreach (Light light in lights)
            {
                if (light.type == LightType.Point)
                {
                    light.enabled = false;
                }
            }
        }
        else if (Day_Night_Change.timerHours == Day_Night_Change.endDayTime)
        {
            foreach (Light light in lights)
            {
                if (light.type == LightType.Point)
                {
                    light.enabled = true;
                }
            }
        }
    }
}