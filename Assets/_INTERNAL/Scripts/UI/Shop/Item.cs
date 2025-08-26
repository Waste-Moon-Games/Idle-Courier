using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [field:SerializeField] public TextMeshProUGUI Name { get; set; }
    [field:SerializeField] public Button Button { get; set; }
}