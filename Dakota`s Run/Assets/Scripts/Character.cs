using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using CnControls;

public class Character : Unit
{
    Vector3 position;

    GameObject checkpoint;
    private int currentImpObj;

    [SerializeField]
    private int currentCountCoin;

    public int CurrentCountCoin
    {
        get { return currentCountCoin; }
        set { currentCountCoin = value; }
    }

    [SerializeField]
    private int lives = 5;
    
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
        currentImpObj = Data.importantScore;
    }

    private void Update()
    {
        CheckGround();
        if (isGrounded) State = CharState.Idle;

        if (CnInputManager.GetAxis("Horizontal") != 0) Run();
        if (isGrounded && CnInputManager.GetButtonUp("Jump")) Jump();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    private void Run()
    {
        Vector3 direction = transform.right * CnInputManager.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if (isGrounded) State = CharState.Run;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public override void ReceiveDamage()
    {
        Lives--;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce((transform.up+(sprite.flipX ? 1 : -1)*transform.right) * 4.0F, ForceMode2D.Impulse);

        Debug.Log(lives + " live`s");

        if (lives <= 0)
        {
            if (currentImpObj < Data.importantScore)
            {
                Lives += 5;
                transform.position = checkpoint.transform.position;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump;
    }
}


public enum CharState
{
    Idle,
    Run,
    Jump
}