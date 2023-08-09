using UnityEngine;
using System.Collections;


public class Player1Controller : MonoBehaviour
{
	//public ParticleSystem Dust;

	[SerializeField] private GameInput gameInput;
	
    public float speed = 5f;

    public Animator anim;
	private Rigidbody2D rb;
    public bool facingRight;
	public SpriteRenderer sprite;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
	// Controls facing direction
	
	 
	public void Jump()
    {
		anim.SetBool("Jump", true) ;
	}

	public void JumpOff()
    {
		anim.SetBool("Jump", false);
	}

	public void Dead()
	{
		anim.SetBool("Dead" , true);
	}

	public void DeadOff()
	{
		anim.SetBool("Dead", false);
	}
	public void Walk()
	{
		anim.SetBool("Walk" , true);
	}

	public void WalkOff()
	{
		anim.SetBool("Walk", false);
	}
	public void Run()
	{
		anim.SetBool("Run" , true);
	}
	public void RunOff()
	{
		anim.SetBool("Run", false);
	}
	public void Attack()
	{
		anim.SetBool("Attack" , true);
	}
	public void AttackOff()
	{
		anim.SetBool("Attack", false);
	}

	void Update()
	{
        Vector2 movement = gameInput.GetMovementVector();
		
		if (movement.x > 0)
		{
			facingRight = false;
			sprite.flipX = facingRight;
            Run();
		
        }
		else if(movement.x < 0)
		{
			facingRight = true;
            sprite.flipX = facingRight;
            Run();
          
        }
        else
        {
			RunOff();
        }
		if (movement.y != 0)
		{
            Run();
         
		}
		
        rb.velocity = movement * speed;
		
    } 
	
}



