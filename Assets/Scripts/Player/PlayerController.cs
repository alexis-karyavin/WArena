using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PhotonView photonView;

    //public int health;
    //public Image bar;
    //public Text textHealth;

    public bool isGrounded;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsLayerGround;

    public Joystick joystick;
    Rigidbody2D rigitBody;
    public float moveSpeed = 10f;
    bool isFacingRight = true;
    Animator animator;


    void Start()
    {
        //health = 100;
        //bar = GameObject.FindGameObjectWithTag("Bar").GetComponent<Image>();
        //textHealth = GameObject.FindGameObjectWithTag("TextHealth").GetComponent<Text>();

        rigitBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

    public void Run()
    {
        float move = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        rigitBody.velocity = new Vector2(move * moveSpeed, rigitBody.velocity.y);

        if (move == 0)
            animator.SetInteger("Anim", 1);
        else
            animator.SetInteger("Anim", 2);
    
        if (move > 0 && !isFacingRight)
            Flip();
        if (move < 0 && isFacingRight)
            Flip();

        if(moveVertical >= .5f && isGrounded)
            Jump();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);  
    }

    void Jump()
    {
        rigitBody.AddForce(transform.up / 1, ForceMode2D.Impulse);
    }

    //public void TakeDamage(int damage)
    //{
    //    health -= damage;
    //    if (health < 0)
    //        Die();
    //}

    //public void Die()
    //{
    //    Destroy(gameObject);
    //}


    void Update()
    {
        if (!photonView.IsMine) return;
        Run();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsLayerGround);

        //bar.fillAmount = (float)health / 100;
        //textHealth.text = health + "%";
    }
}
