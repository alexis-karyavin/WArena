using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Button settings;
    public GameObject panel_settings;
    public GameObject panel_menu;
    public Slider slider_music;

    private void Start()
    {
        settings = GameObject.Find("Settings_btn").GetComponent<Button>();
        settings.onClick.AddListener(delegate { OpenSettings(); });
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            panel_settings.SetActive(false);
            panel_menu.SetActive(true);
        }   
    }

    private void Update()
    {
        AudioListener.volume = slider_music.value;
    }

    public void OpenSettings()
    {
        panel_menu.SetActive(false);
        panel_settings.SetActive(true);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
