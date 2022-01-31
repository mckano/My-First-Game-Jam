using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneManager : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Oktosha_Start");
    }

    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/mckano/My-First-Game-Jam");
    }
}
