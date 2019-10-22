using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppCommands : MonoBehaviour
{
    bool gamePaused = false;
    public Transform playerStart;
    [SerializeField] GameObject pauseMenu;   
    void Awake()
    {
        MakeSingleton();
    }
    public static AppCommands Instance { get; set; }
    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Quit();
        resetLevel();
        PauseMenu();
    }
    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Application.Quit();
        }
    }

     public void QuitButton()
    {
            Application.Quit();
    }
    public void PauseMenu(){
        if(Input.GetButtonDown("Start")){
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
            if(gamePaused){
                Time.timeScale =1f;
                gamePaused = false;
            } else{
                Time.timeScale =0f;
                gamePaused = true;
            }
        }
    }
    public void PauseMenuButton(){
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
            if(gamePaused){
                Time.timeScale =1f;
                gamePaused = false;
            } else{
                Time.timeScale =0f;
                gamePaused = true;
            }
        
    }
    public void resetLevel()
    {
        if (Input.GetButtonDown("Select"))
        {
            SceneManager.LoadScene("main");
        }
    }
    public void resetLevelButon()
    {
            SceneManager.LoadScene("main");
    }

}
