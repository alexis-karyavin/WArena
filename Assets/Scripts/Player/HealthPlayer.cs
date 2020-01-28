using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    int health;
    Image bar;
    Text textHealth;
    PhotonView photonView;
    Canvas canvaLose, canvaGame;
    GameManager gameManager;

    void Start()
    {
        health = 100;
        bar = GameObject.FindGameObjectWithTag("Bar").GetComponent<Image>();
        textHealth = GameObject.FindGameObjectWithTag("TextHealth").GetComponent<Text>();
        photonView = GetComponent<PhotonView>();

        gameManager = new GameManager();
        //canvaLose = GameObject.FindGameObjectWithTag("CanvasLose").GetComponent<Canvas>();
        //canvaGame = GameObject.FindGameObjectWithTag("CanvasGame").GetComponent<Canvas>();
        //canvaLose.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (!photonView.IsMine) return;
        bar.fillAmount = (float)health / 100;
        textHealth.text = health + "%";
    }

    public void TakeDamage(int damage)
    {
        if (!photonView.IsMine) return;
        health -= damage;
        if (health < 0)
        {
            Die();
            gameManager.Leave();
            //ShowCanvas();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void ShowCanvas()
    {
        canvaGame.gameObject.SetActive(false);
        canvaLose.gameObject.SetActive(true);
    }

}
