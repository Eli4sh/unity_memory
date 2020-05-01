using Memory.Structs;
using TMPro;
using UnityEngine;

namespace Menu.UserInterface
{
    public class UI_LastGameResult : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _durationText;

        [SerializeField]
        private TMP_Text _gameTypeText;

        [SerializeField]
        private TMP_Text _levelText;

        [SerializeField]
        private TMP_Text _percentageText;

        public void SetResult(MemoryGameResult result)
        {
            _gameTypeText.text = GameType.MEMORY.ToString();
            _levelText.text = $"Game Level: {result.Level}";
            _durationText.text = $"Seconds left: {result.SecondsLeft}";
            _percentageText.text = $"Level completeness: {result.PercentComplete}";
        }
    }
}