using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Oktosha_Environment");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Oktosha_Credits");
    }
}
