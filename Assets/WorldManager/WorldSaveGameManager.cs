using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class WorldSaveGameManager : Singleton<WorldSaveGameManager>
{
    [SerializeField] private int worldSceneIndex = 1;
    public IEnumerator LoadNewGame()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
        yield return null;
    }

    public int GetWorldSceneIndex()
    {
        return worldSceneIndex;
    }
}
