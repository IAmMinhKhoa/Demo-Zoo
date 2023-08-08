using UnityEngine;
using System.Collections;


public class Player1Controller : MonoBehaviour
{
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		if (moveHorizontal > 0)
		{
			facingRight = false;
			sprite.flipX = facingRight;
			Walk();
		}
		else if(moveHorizontal <0)
		{
			facingRight = true;
            sprite.flipX = facingRight;
            Walk();

        }
        else
        {
            WalkOff();

        }
        if (moveVertical != 0)
        {
            Run();
        }
        else
        {
            RunOff();

        }
		
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;
		Debug.Log(moveHorizontal);
    } 


}



