using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlayerOne == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetBool("Turn_Left", true);
                animator.SetBool("Turn_Right", false);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                animator.SetBool("Turn_Left", false);
                animator.SetBool("Turn_Right", false);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetBool("Turn_Left", false);
                animator.SetBool("Turn_Right", true);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                animator.SetBool("Turn_Left", false);
                animator.SetBool("Turn_Right", false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                animator.SetBool("Turn_Left", true);
                animator.SetBool("Turn_Right", false);
            }
            else if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                animator.SetBool("Turn_Left", false);
                animator.SetBool("Turn_Right", false);
            }

            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                animator.SetBool("Turn_Left", false);
                animator.SetBool("Turn_Right", true);
            }
            else if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                animator.SetBool("Turn_Left", false);
                animator.SetBool("Turn_Right", false);
            }
        }

        
    }
}
