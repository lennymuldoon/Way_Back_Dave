using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip deathSound;


    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    Vector2 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.name == "Portal")
       {
           NextLevel.Instance.transitionToNextLevel();
       }

       if (collision.gameObject.name == "End")
       {
           Application.Quit();
       }

       if (collision.gameObject.name == "Restart")
       {
           SceneManager.LoadScene(1);
       }

      if (collision.gameObject.tag == "Floor")
      {
        transform.position = respawnPoint;
        audioSource.PlayOneShot(deathSound);
      }
    }
}