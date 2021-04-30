#if UNITY_EDITOR
using UnityEditor;

namespace UnityBase
{
    [InitializeOnLoadAttribute]
    public class TimeTrackerTriggerOnPlayModeChange
    {
        static TimeTrackerTriggerOnPlayModeChange()
        {
            EditorApplication.playModeStateChanged += LogPlayModeState;


        }

        private static void LogPlayModeState(PlayModeStateChange state)
        {
            TimeTracker.OnTrigger();
        }


    }
}
#endif