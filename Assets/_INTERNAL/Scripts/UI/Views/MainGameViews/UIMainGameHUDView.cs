using TMPro;
using UnityEngine;

namespace UI.Views.MainGameViews
{
    public class UIMainGameHUDView : MonoBehaviour
    {
        [Header("Player Economy Info")]
        [SerializeField] private TextMeshProUGUI _playerMoney;
        [SerializeField] private TextMeshProUGUI _playerCrystalls;

        [Space(10), Header("Player Stats Info")]
        [SerializeField] private TextMeshProUGUI _playerRating;
    }
}