using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMovement : MonoBehaviour
{

    //общее
    private Vector3 targetVelocity; // новый вектор что бы присваивать его в rb.velocity
    //------------------------

    //references
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField] private Joystick joystick;
    //-----------------------------

    //Move
    [Header("Move")]
    [SerializeField] private float movementSpeed;
    private float horizontalMove;
    //-----------------------


    //Jump
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [Tooltip("Как делаеко идет луч который проверяет землю под ногами  ")]
    [SerializeField] float JumpRayDist = 0.5f; // на сколько далеко идет луч который отвечает за прикосновение 
    //-----------------------

    //UI
    [Header("UI")]
    [SerializeField]private Image[] UISprites;
    //-----------------------
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        MoveButtonUp();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal;
        anim.SetFloat("horizontalMove", Mathf.Abs(horizontalMove));
    }


    void FixedUpdate()
    {
        targetVelocity.x = horizontalMove * Time.fixedDeltaTime * movementSpeed;
        targetVelocity.y = rb.velocity.y;
        rb.velocity = targetVelocity;
        Flip();
    }

   

    //public void MoveLeftButtonDown(Image leftSprite)
    //{
    //    leftSprite.color = new Color(leftSprite.color.r, leftSprite.color.g, leftSprite.color.b, 1);
    //    horizontalMove = -1;
    //    Flip();

    //}

    //public void MoveRightButtonDown(Image rightSprite)
    //{
    //    rightSprite.color = new Color(rightSprite.color.r, rightSprite.color.g, rightSprite.color.b, 1);
    //    horizontalMove = 1;
    //    Flip();
    //}

    public void MoveButtonUp( )
    {
        foreach (Image image in UISprites)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
        }

        horizontalMove = 0;
    }


    void Flip()
    {
        if (horizontalMove < 0)
            this.transform.rotation = new Quaternion(0f, 180, 0f, 0);
        if (horizontalMove > 0)
            this.transform.rotation = new Quaternion(0f, 0f, 0f, 0);

    }

    public void Jump(Image jumpSprite)
    {
        float multiply = 1;
        jumpSprite.color = new Color(jumpSprite.color.r, jumpSprite.color.g, jumpSprite.color.b, 1);

        CheckIsGrounded();

        //проверка 

        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce * multiply, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }

        
    }

    void CheckIsGrounded()
    {
        isGrounded = false;
        Debug.DrawRay(this.transform.position, Vector2.down * JumpRayDist, Color.blue, 0.3f);
        isGrounded = Physics2D.Raycast(this.transform.position, Vector2.down, JumpRayDist, groundLayer);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RBorder"))
        {
            LoadManager.instance.RightSceneLoad();
        }
        if (other.CompareTag("LBorder"))
        {
            LoadManager.instance.LeftSceneLoad();
        }
        
    }

}
