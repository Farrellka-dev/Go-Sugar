using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    public enum ProjectAxis { onlyX = 0, xAndY = 1 };
    public ProjectAxis projectAxis = ProjectAxis.onlyX;
    public float speed = 150;
    public float addForce = 7;
    public bool lookAtCursor;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode addForceButton = KeyCode.Space;
    public bool isFacingRight = true;
    private Vector3 direction;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
    private float rotationY;
    private bool jump;
    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    //private Rigidbody2D _rigidbody;
    private Animator _animatorController;
    private float _walkTime = 0;


    void Start()
    {
        _transform = GetComponent<Transform>();
        _animatorController = GetComponent<Animator>();
       _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
        body = GetComponent<Rigidbody2D>();
        body.fixedAngle = true;

        if (projectAxis == ProjectAxis.xAndY)
        {
            body.gravityScale = 0;
            body.drag = 10;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground") //Если стоим на земле, то можем прыгать.
        {
            body.drag = 10;
            jump = true;
          //  _animatorController.Play("Idle");
        }
    }

    void OnCollisionExit2D(Collision2D coll) //Если не стоим на земле, не можем прыгать.
    {
        if (coll.transform.tag == "Ground")
        {
            body.drag = 0;
            jump = false;
            _animatorController.Play("Jump");
        }
    }

    void FixedUpdate()
    {
        body.AddForce(direction * body.mass * speed);

        if (Mathf.Abs(body.velocity.x) > speed / 100f)
        {

            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
           // _animatorController.Play("Run");
        }

        if (projectAxis == ProjectAxis.xAndY)
        {
            if (Mathf.Abs(body.velocity.y) > speed / 100f)
            {
                body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
                //_animatorController.Play("Run");
            }
        }
        else
        {
            if (Input.GetKey(addForceButton) && jump)
            {
                body.velocity = new Vector2(0, addForce);
                //_animatorController.Play("Idle");
            }
        }
    }

    void Flip()
    {
        if (projectAxis == ProjectAxis.onlyX)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void Update()
    {
        if (lookAtCursor)
        {
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (Input.GetKey(upButton)) vertical = 1;
        else if (Input.GetKey(downButton)) vertical = -1; else vertical = 0;

        if (Input.GetKey(leftButton)) horizontal = -1;
        else if (Input.GetKey(rightButton)) horizontal = 1; else horizontal = 0;

        if (projectAxis == ProjectAxis.onlyX)
        {
            direction = new Vector2(horizontal, 0);
        }
        else
        {
            if (Input.GetKeyDown(addForceButton)) speed += addForce; else if (Input.GetKeyUp(addForceButton)) speed -= addForce;
            direction = new Vector2(horizontal, vertical);
        }

        if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
    }

    public void MoveRight()
    {
            //_animatorController.Play("Run");
    }
    

    public void MoveLeft()
    {
       
            //_animatorController.Play("Run");
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Jump;
            //_animatorController.Play("Jump");
        }
    }

    private void Idle()
    {
        //_moveState = MoveState.Idle;
       // _animatorController.Play("Idle");
    }

    enum DirectionState
    {
        Right,
        Left
    }

    enum MoveState
    {
        Idle,
        Run,
        Jump
    }
}
