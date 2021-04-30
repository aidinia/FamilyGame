#if UNITY_EDITOR

namespace UnityBase
{
    public class TimeTrackerTriggerOnSaveAssets : UnityEditor.AssetModificationProcessor
    {
        public static string[] OnWillSaveAssets(string[] paths)
        {
            TimeTracker.OnTrigger();
            return paths;
        }




        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            TimeTracker.OnTrigger();
        }
    }
}
#endif
