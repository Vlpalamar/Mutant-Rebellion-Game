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
    private Animator anim;


    //-----------------------------

    //Move
    [Header("Move")]
    [SerializeField] private float movementSpeed;
   

    //-----------------------


    //Jump
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [Tooltip("Как делаеко идет луч который проверяет землю под ногами  ")]
    [SerializeField] float JumpRayDist = 0.5f; // на сколько далеко идет луч который отвечает за прикосновение 
    private bool isGrounded;
    //-----------------------

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }


    public void Move(float horizontalMove)
    {
        anim.SetFloat("horizontalMove", Mathf.Abs(horizontalMove));
        targetVelocity.x = horizontalMove * Time.fixedDeltaTime * movementSpeed;
        targetVelocity.y = rb.velocity.y;
        rb.velocity = targetVelocity;
        Flip(horizontalMove);
    }
    

    void Flip(float horizontalMove)
    {
        if (horizontalMove < 0)
            this.transform.rotation = new Quaternion(0f, 180, 0f, 0);
        if (horizontalMove > 0)
            this.transform.rotation = new Quaternion(0f, 0f, 0f, 0);

    }

    public void Jump()
    {
        float multiply = 1;
   
        if (CheckIsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce * multiply, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }

    bool CheckIsGrounded()
    {
   
        Debug.DrawRay(this.transform.position, Vector2.down * JumpRayDist, Color.blue, 0.3f);
        return Physics2D.Raycast(this.transform.position, Vector2.down, JumpRayDist, groundLayer);

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
