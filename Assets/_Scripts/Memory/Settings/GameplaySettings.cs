using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Settings
{
    [CreateAssetMenu(fileName = "Gameplay Settings", menuName = "Memory/Settings/Visual", order = 0)]
    public class GameplaySettings : ScriptableObject
    {
        [Tooltip(tooltip: "Level duration in seconds")]
        public int LevelDuration;

        [Tooltip(tooltip: "Number of pairs to create in game")]
        public int MemoryPairs;
    }
}