using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Controller : MonoBehaviour {

    // max prędkość
    public float maxSpeed = 5f;

    //siła/prędkość skoku
    public float jumpspeed = 5f;

    // pokaż sprite w którą stronę jest zwrócony
    bool facingRight = true;

   // private float movement = 0f;
    private Rigidbody2D rigidBody;

    //pobierz referrencję do animator
    private Animator anim;
    #region
    /*
    //nie dotyka ziemi
    bool grounded = false;

    //
    public Transform groundCheck;

    // jak duże jest koło gdy sprawdzamy odległość od podłoża
    float groundRadius = 0.2f;

    //siła skoku
    public float jumpForce = 700f;

    public LayerMask whatIsGround;
    */
    #endregion
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        #region
        // true/false czy podłoże (ground) dotyka "whatIsGround z GroundRadius
        //  grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //pokaż "animator" że jesteśmy na ziemi
        //anim.SetBool("Ground", grounded);
        //pobież prękość z jaką poruszamy się na górę/na dół
        //anim.SetFloat("vSpeed", rigidBody.velocity.y);
        #endregion

        //pobierz kierunek ruchu
        float move = Input.GetAxis("Horizontal");
         
        // dodaj prękość do rigidBody - kierunek ruchu * prędkość
        rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);

        // zmień wartość float w speed
        anim.SetFloat("speed", Mathf.Abs(move));

        if (move > 0f)
        {
            // Jeśli ruch > 0 obróć sprita po osi X
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(move < 0f)
        {
            // Jeśli ruch < 0 obróć sprita po osi X
            GetComponent<SpriteRenderer>().flipX = false;
        }

        #region
        /*else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }*/
        #endregion
        //Jeśli wciśnięta spacja (jump)
        //if (grounded && Input.GetButtonDown("Jump")){
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Ground", false);
         //zmień prędkość na osi Y
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpspeed);
        }
    }


}
