using UnityEngine;
using Unity.Netcode;

namespace MenuScene
{
    public class TitleScreenManager : MonoBehaviour
    {
        public void StartNetworkAtHost()
        {
            Debug.Log("Starting network at host");
            NetworkManager.Singleton.StartHost();
        }

        public void StartNewGame()
        {
            StartCoroutine(WorldSaveGameManager.Instance.LoadNewGame());
        }
    }
}
