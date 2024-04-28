using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelSettings;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToLevelOne(){
        SceneManager.LoadScene("1_mundo1");
    }

    public void ToggleSettings(){
        GameManager.Instance.ToggleSettings();
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void HoverButton() {
        AudioManager.Instance._sfx_PlayOnce(AudioManager.Instance.sfx_button);
    }



}
