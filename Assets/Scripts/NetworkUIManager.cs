using UnityEngine;
using Unity.Netcode;

public class NetworkUIManager : MonoBehaviour
{
    public void StartHost()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartHost();
        }
    }

    public void StartClient()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}
