using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Settings
{
    [CreateAssetMenu(fileName = "Gameplay Settings", menuName = "Memory/Settings/Gameplay", order = 0)]
    public class GameplaySettings : ScriptableObject
    {
        [Tooltip(tooltip: "Level duration in seconds")]
        public int LevelDuration;

        [Tooltip(tooltip: "Number of pairs to create in game")]
        public int MemoryPairs;

        [Tooltip(tooltip: "Number of Rows/Columns in card grid")]
        public Vector2Int GridRowsColumns;
    }
}