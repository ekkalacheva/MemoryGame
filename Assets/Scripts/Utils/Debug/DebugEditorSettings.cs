#if UNITY_EDITOR
using UnityEngine;

namespace MemoryGame.Utils
{
    [CreateAssetMenu(fileName = "DebugEditorSettings", menuName = "MemoryGame/Debug/DebugEditorSettings")]
    public class DebugEditorSettings : ScriptableObject
    {
        [SerializeField] bool _isTablet;

        public bool IsTablet => _isTablet;
    }
}
#endif
