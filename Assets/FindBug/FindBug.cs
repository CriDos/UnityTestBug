using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace HardWorld.FindBug
{
    [InitializeOnLoad]
    public static class FindBug
    {
        private const string StartTest = "StartTest";
        private static readonly float OldTime;

        static FindBug()
        {
            OldTime = Time.realtimeSinceStartup;
            EditorApplication.update += Update;
        }

        private static void Update()
        {
            var deltaTime = Time.realtimeSinceStartup - OldTime;

            if (EditorPrefs.GetBool(StartTest))
            {
                if (deltaTime >= 0)
                {
                    EditorApplication.isPlaying = !EditorApplication.isPlaying;
                }
            }
        }

        [MenuItem("Test/Stop %s")]
        static void Stop()
        {
            EditorPrefs.SetBool(StartTest, false);
        }

        [MenuItem("Test/Start")]
        static void Start()
        {
            EditorPrefs.SetBool(StartTest, true);
            EditorSceneManager.OpenScene("Assets/FindBug/TestBug.unity");
            EditorApplication.isPlaying = true;
        }
    }
}