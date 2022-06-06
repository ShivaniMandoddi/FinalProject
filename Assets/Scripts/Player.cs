using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    #region PUBLIC VARIABLES
    public int playerSpeed;
    public int playerJumpForce;
    #endregion

    #region PRIVATE VARIABLES
    private PlayerControl controls;
    InputAction movement;
    Rigidbody2D rb;
    private bool IsJump = false;
    #endregion


    #region MONOBEHAVIOUR METHODS
    void Awake()
    {
        controls = new PlayerControl();                   // Creating Input System Object
        controls.Player.Movement.performed += ctx => Movement(ctx.ReadValue<Vector2>());   // Adding Movement Event
        controls.Player.Jump.performed += ctx => Jump();     // Adding Jump Event

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   

    }
    private void Update()
    {

    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==Constants.GROUND_LAYER_NUMBER)
        {
            IsJump = false;
        } 
        if(collision.gameObject.layer==Constants.ENEMY_LAYER_NUMBER)     // Collision with Enemy 
        {
            if (IsJump)               // PLayer in jumping state can kill the enemy
            {
                Destroy(collision.gameObject);
            }
            else if(this.gameObject.transform.localScale.x>1f) // If player have a power
            {
                this.gameObject.transform.localScale = Vector3.one;
            }
            else  // If player doesn't have power and collided with enemy 
            {
                Destroy(this.gameObject);
            }

        }
        if(collision.gameObject.layer==Constants.COIN_LAYER_NUMBER)
        {
            ScoreManager.Instance.Score(2);
        }
        if(collision.gameObject.tag=="Power")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.ActivatingSuperPower(this.gameObject);
            //GameManager.Instance.ActivatingMegaPower(this.gameObject);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Treasure")    // When reaches the end of the level
        {
            
        }
    }
    #endregion

    #region PUBLIC METHODS

    #endregion
    #region PRIVATE METHODS
    void Movement(Vector2 value)
    {
        rb.velocity = value * playerSpeed;
    }
    void Jump()
    {
        IsJump = true;
        rb.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
        

    }
    #endregion


}
