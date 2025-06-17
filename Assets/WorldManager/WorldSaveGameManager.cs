using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class WorldSaveGameManager : Singleton<WorldSaveGameManager>
{
    [SerializeField] private int worldSceneIndex = 1;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

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
