using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    private PhotonView photonView;
    private Button btnShoot;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        btnShoot = GameObject.FindGameObjectWithTag("btnFire").GetComponent<Button>();
        btnShoot.onClick.AddListener(Shoot);
    }
   
    public void Shoot()
    {
        if (photonView.IsMine) PhotonNetwork.Instantiate(bullet.name, firePoint.position, firePoint.rotation);
    }
}
