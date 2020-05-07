using UnityEngine;

namespace Memory.Settings
{
    [CreateAssetMenu(fileName = "Visual Settings", menuName = "Memory/Settings/Visual", order = 0)]
    public class VisualSettings : ScriptableObject
    {
        public Sprite CardFrame;
        [Tooltip(tooltip: "Card fade duration in seconds")]
        public float CardFadeDuration;
    }
}