using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Level
{
    public enum SceneIndex
    {
        Start = 0, Game = 2,
    }

    public static class GameScene
    {
        public static AsyncOperation LoadOperation { get; private set; }

        public static void Load(SceneIndex nextScene)
        {
            LoadOperation = SceneManager.LoadSceneAsync((int)nextScene);
            LoadOperation.allowSceneActivation = false;
        }
    }
}
