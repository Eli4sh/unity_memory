using UnityEngine;

namespace Memory.Settings
{
    [CreateAssetMenu(fileName = "Gameplay Settings", menuName = "Memory/Settings/Gameplay", order = 0)]
    public class GameplaySettings : ScriptableObject
    {
        [Tooltip(tooltip: "Card flip duration in seconds")]
        public float CardFlipDuration;

        [Tooltip(tooltip: "Number of Rows/Columns in card grid")]
        public Vector2Int GridRowsColumns;

        [Tooltip(tooltip: "Level duration in seconds")]
        public int LevelDuration;

        [Tooltip(tooltip: "Number of pairs to create in game")]
        public int MemoryPairs;
    }
}