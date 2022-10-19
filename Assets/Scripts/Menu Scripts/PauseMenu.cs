using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
public bool isPaused = false;

public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Cancel")>0){
            Debug.Log("TEst Pause");
            if(isPaused == true){
                Resume();
            }
            else{

                pauseMenuUI.SetActive(true);
            }
        }
    }

    public void Pause(){
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume(){
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMenu(){
        Debug.Log("Load");
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
