using UnityEngine;
using Unity.Netcode;

public class NetworkUIManager : MonoBehaviour
{
    public void StartServer()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartServer();
            Debug.Log("Server started.");
        }
        else
        {
            Debug.LogError("NetworkManager.Singleton is null. Make sure it's set up correctly.");
        }
    }
}
