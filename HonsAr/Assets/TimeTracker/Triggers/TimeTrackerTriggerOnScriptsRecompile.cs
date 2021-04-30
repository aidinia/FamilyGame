#if UNITY_EDITOR
using UnityEditor;

namespace UnityBase
{
    [InitializeOnLoad]
    public class TimeTrackerTriggerOnScriptsRecompile
    {
        static TimeTrackerTriggerOnScriptsRecompile()
        {
            TimeTracker.OnTrigger();
        }
    }
}
#endif