using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    public static GameManager Instance; 
    public GameObject panelSettings;

    public static bool dead = false;

    public static int vidas = 5;
    public static int puntos = 0;

    void Awake(){
        //Singleton
        if (Instance != null && Instance!= this){
            Destroy(this.gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
       panelSettings.SetActive(false); 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            ToggleSettings();
        }
        if (dead == true) {
            Gameover();
        }
    }

    public void ToggleSettings(){
        //panelSettings.SetActive(!panelSettings.activeSelf); 

        if (panelSettings.activeSelf == true){
            panelSettings.SetActive(false);
        } else {
                   panelSettings.SetActive(true); 
        }
                   

        Debug.Log(panelSettings.activeSelf); 
    }

    public void GoToMainMenu(){
        ToggleSettings();
        SceneManager.LoadScene("0_mainMenu");
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void Gameover(){
        SceneManager.LoadScene("GameOver");
        dead = false;
        vidas = 5;
    }

    //sfx buttons
    public void HoverButton() {
        AudioManager.Instance._sfx_PlayOnce(AudioManager.Instance.sfx_button);
    }
}
