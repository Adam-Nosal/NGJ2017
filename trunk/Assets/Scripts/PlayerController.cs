using UnityEngine;
using System.Collections;
using Helpers;

public class PlayerController : MonoBehaviour
{

 
    [Header("Controllers")]
    [SerializeField]
    private Rigidbody2D mRigidbody2d;
    
    private Transform mTransform;
    

    [Header("Movement")]
    [SerializeField]
    [Range(1.0f,15.0f)]
    private float speed = 3.5f;
    [SerializeField]
    private float rotationSpeed = 2.0f;

    float rot_z = 0;




    [SerializeField] private Vector2 lookVector;
    [SerializeField] private Vector3 destinationRotation;
    [SerializeField] private int healthPoints = 100;

    private float movement;



    void Awake()
    {
        InitVariables();
            
    }

    private void FixedUpdate()
    {
        Vector2 lVector = GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, GamepadInput.GamePad.Index.One);
        lVector.Normalize();
        if (Mathf.Abs(lVector.x) > 0.01f || Mathf.Abs(lVector.y) > 0.01f)
        {
            rot_z += (-1) * lVector.x * rotationSpeed;
        }
    }
    void Update()
    {

        
        //if (Mathf.Abs(lookVector.x) > 0.01f)
        //{
            //Vector3 diff = lookVector;// - transform.position;
            //diff.Normalize();
            //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        //}

        movement = GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick, GamepadInput.GamePad.Index.One).y;
        int forward = movement > 0 ? 1 : -1;
        if (Mathf.Abs( movement) > 0.25f)
        {
          //  mRigidbody2d.velocity = speed * forward * this.transform.forward;// lookVector.normalized;
            transform.position += speed * forward * Time.deltaTime * transform.right;      
        }
        else
        {
            mRigidbody2d.velocity = Vector2.zero;

            //DecreaseVelocity();

        }

        //speed -= Mathf.PerlinNoise(Time.time, 0);

        //Debug.Log(" look" + GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, GamepadInput.GamePad.Index.One).ToString());



    }

    private void DecreaseVelocity()
    {
        float xVelo = mRigidbody2d.velocity.x;
        if(xVelo > 0)
        {
            xVelo -= Mathf.PerlinNoise(Time.time, 0);
            xVelo = Mathf.Min(0, xVelo);
        }
        else
        {
            xVelo += Mathf.PerlinNoise(Time.time, 0);
            xVelo = Mathf.Max(0, xVelo);
        }

        float yVelo = mRigidbody2d.velocity.y;
        if (yVelo > 0)
        {
            yVelo -= Mathf.PerlinNoise(Time.time, 0);
            yVelo = Mathf.Min(0, yVelo);
        }
        else
        {
            yVelo += Mathf.PerlinNoise(Time.time, 0);
            yVelo = Mathf.Max(0, yVelo);
        }

        Vector2 newVelocity = new Vector2(xVelo,yVelo);
       
        mRigidbody2d.velocity = newVelocity;// Vector2.zero;

    }


    public void Damage(int i)
    {
        healthPoints -= i;
        
    }

    private void InitVariables()
    {
        
        if (mRigidbody2d == null)
            mRigidbody2d = this.GetComponent<Rigidbody2D>();
        if (mTransform == null)
            mTransform = this.GetComponent<Transform>();
    }





}
