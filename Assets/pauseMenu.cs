using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject CarChangePanel;
    
    public void pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }
    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        resume();
    }

    public void home()
    {
        SceneManager.LoadScene(0);
    }

    public void opencarchange()
    {
        CarChangePanel.SetActive(true);
    }

 

}
