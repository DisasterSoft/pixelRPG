using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class player_controller : MonoBehaviour
{
    public string HorizontalAxis = "Horizontal";
    public string VerticalAxis = "Vertical";
    public static GameObject player;
    public float moveSpeed;
    Animator anim;
    SpriteRenderer render;
    Rigidbody2D rb;
    public AudioSource _as;
    private Vector3 direction;
    private float xMin, xMax, yMin, yMax;
    public bool controlls = true;
    public bool moveLeftB = false;
    public bool moveRightB = false;
    public bool moveUpB = false;
    public bool moveDownB = false;
   
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        moveSpeed = 3;
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        playFootStep();
        if (Input.GetAxis("Horizontal") > 0.7f)
        {
           
            moveRight();
        }
        else if(Input.GetAxis("Horizontal") < -0.7f)
        {
           
            moveLeft();
        }
        else if (Input.GetAxis("Vertical") > 0.7f)
        {

            moveUP();
        }
        else if(Input.GetAxis("Vertical") < -0.7f)
        {
         
            moveDown();
        }
        else
        {
            relaseButton();
        }
  

        if (moveUpB)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (moveDownB)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (moveLeftB)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (moveRightB)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
       if(moveLeftB || moveRightB || moveUpB || moveDownB)
        {
            anim.speed = 1;
        }
        else
        {
            anim.speed = 0;
        }
      
    }
   public void moveUP()
    {
        moveUpB = true;
        moveDownB = false;
        moveLeftB = false;
        moveRightB = false;

           
                anim.SetBool("MoveX", false);
                anim.SetBool("MoveUp", true);
                anim.SetBool("MoveDown", false);
                anim.speed = 1;
           
    }
    public void moveDown()
    {
        moveUpB = false;
        moveDownB = true;
        moveLeftB = false;
        moveRightB = false;
       
        anim.SetBool("MoveX", false);
                anim.SetBool("MoveUp", false);
                anim.SetBool("MoveDown", true);
                anim.speed = 1;
    }
    public void moveLeft()
    {
        moveUpB = false;
        moveDownB = false;
        moveLeftB = true;
        moveRightB = false;
       
        anim.SetBool("MoveX", true);
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveDown", false);
            render.flipX = false;
            anim.speed = 1;
       
    }
    public void moveRight()
    {
        moveUpB = false;
        moveDownB = false;
        moveLeftB = false;
        moveRightB = true;
       
        anim.SetBool("MoveX", true);
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveDown", false);
            render.flipX = true;
            anim.speed = 1;
    }
    public void relaseButton()
    {
        moveUpB = false;
        moveDownB = false;
        moveLeftB = false;
        moveRightB = false;
        _as.enabled = false;
        _as.loop = false;
    }
    public void playFootStep()
    {
        if(moveUpB || moveDownB || moveLeftB || moveRightB )
        {
            _as.enabled = true;
            _as.loop = true;
        } 
    }

}
