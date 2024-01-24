using UnityEngine;

public class MetalAnimation : MonoBehaviour
{
    public float speed = 0.3f; // Скорость изменения масштаба объекта
    public float minScale = 0.95f; // Минимальное значение масштаба
    public float maxScale = 1.15f; // Максимальное значение масштаба

    private bool isScalingUp = true; // Флаг направления масштабирования

    void Update()
    {
        // Изменение масштаба объекта
        if (isScalingUp)
        {
            transform.localScale += new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.localScale.x >= maxScale)
            {
                isScalingUp = false;
            }
        }
        else
        {
            transform.localScale -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.localScale.x <= minScale)
            {
                isScalingUp = true;
            }
        }
    }
}
