using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_screen : MonoBehaviour
{
    public GameObject Panel_home_screen;
    public GameObject Panel_authorization;
    public GameObject Panel_main_menu;
    public Text text_greeting;
    public InputField Login_field;
    public InputField Password_field;
    public Animator Panel_authorization_animation;
    public Button Create_room_btn;


    public void LoadMenuAuthorization()
    {
        Panel_home_screen.SetActive(false);
        Panel_authorization.SetActive(true);
    }

    public void Authorization()
    {
        if (Login_field.text.Length < 1 || Password_field.text.Length < 1)
        {
            Login_field.placeholder.color = Color.red;
            Password_field.placeholder.color = Color.red;
        } else
        {
            Panel_authorization_animation.SetBool("isOpened", false);
            text_greeting.text = "Welcome " + Login_field.text + "!";
        }
    }

    public void Guest()
    {
        Panel_authorization_animation.SetBool("isOpened", false);
        Create_room_btn.gameObject.SetActive(false);

    }
}
