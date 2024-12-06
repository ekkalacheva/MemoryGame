using UnityEngine;

namespace MemoryGame.Utils
{
    public class DeviceUtils
    {
        public static bool IsTablet
        {
            get
            {
#if UNITY_EDITOR
                var debugSettings = DebugEditorUtils.GetDebugSettings();
                return debugSettings?.IsTablet ?? true;
#endif
                if (!_isTablet.HasValue)
                {
                    _isTablet = IsTabletDevice();
                }

                return _isTablet.Value;
            }
        }

        private static bool? _isTablet;

        private static bool IsTabletDevice()
        {
            float ssw = Screen.width > Screen.height ? Screen.width : Screen.height;

            if (ssw < 800) return false;

            if (Application.platform == RuntimePlatform.Android ||
                Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.WindowsEditor)
            {
                float screenWidth = Screen.width / Screen.dpi;
                float screenHeight = Screen.height / Screen.dpi;
                float size = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
                if (size >= 6.5f) return true;
            }

            return false;
        }
    }
}
