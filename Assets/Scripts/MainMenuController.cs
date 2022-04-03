using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private Canvas howToPlayCanvas;


    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void HowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }

    public void BackToMenu()
    {
        howToPlayCanvas.enabled = false;
    }

} // class

