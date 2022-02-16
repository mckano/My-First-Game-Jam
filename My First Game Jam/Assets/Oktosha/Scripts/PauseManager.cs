using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isListeningInput = true;
    public bool isPaused { private set; get; } = false;

    public GameObject pauseMenu;
    private GameObject player;
    private GameObject reloadManager;

    private void Start()
    {
        reloadManager = GameObject.Find("ReloadManager");
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (isListeningInput && !isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PerformPause();
        }
        else if (isListeningInput && isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PerformResume();
        }
    }

    public void PerformPause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        player.GetComponent<PlayerMovement>().isListeningInput = false;
        player.GetComponent<OnionLayerManager>().isListeningInput = false;
        reloadManager.GetComponent<ReloadScene>().isListeningInput = false;
    }

    public void PerformResume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        player.GetComponent<PlayerMovement>().isListeningInput = true;
        player.GetComponent<OnionLayerManager>().isListeningInput = true;
        reloadManager.GetComponent<ReloadScene>().isListeningInput = true;
    }
}
