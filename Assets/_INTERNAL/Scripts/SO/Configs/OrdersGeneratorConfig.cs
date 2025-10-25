using UnityEngine;

[CreateAssetMenu(fileName = "OrdersGeneratorConfig", menuName = "Configs/OrdersGeneratorConfig")]
public class OrdersGeneratorConfig : ScriptableObject
{
    [Tooltip("Базовое количество генерируемых заказов")]
    [field: SerializeField] public int InitialCountItemGenerated {  get; private set; }

    [Tooltip("Минимальное расстояние для заказов")]
    [field: SerializeField] public float MinDistance { get; private set; }
    [Tooltip("Максимальное расстояние для заказов")]
    [field: SerializeField] public float MaxDistance { get; private set; }


    [Tooltip("Минимальный множитель за срочность")]
    [field: SerializeField] public float MinUrgencyMultiplier { get; private set; }
    [Tooltip("Максимальный множитель за срочность")]
    [field: SerializeField] public float MaxUrgencyMultiplier { get; private set; }


    [Tooltip("Минимальное количество товаров")]
    [field:SerializeField] public int MinItemCount { get; private set; }
    [Tooltip("Максимальное количество товаров")]
    [field:SerializeField] public int MaxItemCount { get; private set; }   
}