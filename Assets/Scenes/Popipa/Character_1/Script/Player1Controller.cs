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

    private Transform footprintsContainer;
    public GameObject footprintsPrefab; // Prefab c?a ??i t??ng d?u chân
    public float footprintInterval = 0.5f; // Kho?ng th?i gian gi?a các d?u chân
    private float lastFootprintTime; // Th?i gian ghi nh?n d?u chân cu?i cùng

    private Vector2 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
        footprintsContainer = new GameObject("FootprintsContainer").transform;
    }
	
	
	 
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

            // Ki?m tra kho?ng th?i gian gi?a các d?u chân
            if (Time.time - lastFootprintTime >= footprintInterval)
            {
                CreateFootprint(-90);
                lastFootprintTime = Time.time;
            }
        }
		else if(movement.x < 0)
		{
			facingRight = true;
            sprite.flipX = facingRight;
            Run();

            // Ki?m tra kho?ng th?i gian gi?a các d?u chân
            if (Time.time - lastFootprintTime >= footprintInterval)
            {
                CreateFootprint(90);
                lastFootprintTime = Time.time;
            }
        }
        else
        {
			RunOff();
        }
		if (movement.y > 0)
		{
            Run();
            if (Time.time - lastFootprintTime >= footprintInterval)
            {
                CreateFootprint(0);
                lastFootprintTime = Time.time;
            }

        }
		else if (movement.y < 0)
        {
            Run();
            if (Time.time - lastFootprintTime >= footprintInterval)
            {
                CreateFootprint(180);
                lastFootprintTime = Time.time;
            }

        }
        // C?p nh?t v? trí c?a nhân v?t
        lastPosition = transform.position;
        rb.velocity = movement * speed;
		
    }
    private void CreateFootprint(float angle)
    {
        // Tính toán góc gi?a v? trí c?a nhân v?t và v? trí hi?n t?i
        Vector2 direction =(Vector2) transform.position - lastPosition;
       
		Vector2 NewPositionFoot = new Vector2(transform.position.x, transform.position.y - 0.55f);
	
        // T?o m?t ??i t??ng d?u chân h??ng v? nhân v?t
        GameObject footprint = Instantiate(footprintsPrefab, NewPositionFoot, Quaternion.Euler(0f, 0f, angle));
        footprint.transform.parent = footprintsContainer;
    }	
}



