using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Click()
    {
        LoadingSceneController.LoadScene("LobbyScene");
    }
}
