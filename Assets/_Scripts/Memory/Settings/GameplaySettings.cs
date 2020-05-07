using System.Collections.Generic;
using Memory.Structs;
using UnityEngine;

namespace Memory.Settings
{
    [CreateAssetMenu(fileName = "Gameplay Settings", menuName = "Memory/Settings/Gameplay", order = 0)]
    public class GameplaySettings : ScriptableObject
    {
        [Tooltip(tooltip: "Number of Rows/Columns in card grid")]
        public Vector2Int GridRowsColumns;

        [Tooltip(tooltip: "Level duration in seconds")]
        public int LevelDuration;
        
        public List<CardPairDetails> CarPairs;

    }
}