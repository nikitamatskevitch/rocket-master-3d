using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum ResourceType
    {
        Coal,
        Metal,
        Phosphor,
        Uran
    }

    public ResourceType resourceType;
    public int resourceIncreaseAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Получаем скрипт управления инвентарем игрока
            Player player = other.GetComponent<Player>();

            // В зависимости от выбранного ресурса, увеличиваем количество у игрока
            switch (resourceType)
            {
                case ResourceType.Coal:
                    player.coal += resourceIncreaseAmount * 3;
                    break;
                case ResourceType.Metal:
                    player.metal += resourceIncreaseAmount * 5;
                    break;
                case ResourceType.Phosphor:
                    player.phosphor += resourceIncreaseAmount * 3;
                    break;
                case ResourceType.Uran:
                    player.uran += resourceIncreaseAmount * 3;
                    break;
            }

            
        }
    }
}
