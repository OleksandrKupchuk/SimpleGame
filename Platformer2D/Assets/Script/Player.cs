using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : CharacterBase
{
    [SerializeField] List<string> listDamageSourceForPlayer;

    [SerializeField] int playerCurrentLevel = 0;

    [SerializeField] int currentExperience;

    public int CurrentExperience
    {
        get => currentExperience; set => currentExperience = value;
    }

    [SerializeField] int maxExperienceInCurrentLevel;

    public int MaxExperienceInCurrentLevel
    {
        get => maxExperienceInCurrentLevel; set => maxExperienceInCurrentLevel = value;
    }

    [SerializeField] int magnificationExperienceForNextLevel;
    [SerializeField] int magnificationHealthForNextLevel;

    public int MagnificationExperienceForNextLevel 
    { 
        get
        {
            magnificationExperienceForNextLevel = (maxExperienceInCurrentLevel * magnificationExperienceForNextLevel) / 100;

            if (playerCurrentLevel <= 5)
            {
                if (magnificationExperienceForNextLevel < 2)
                {
                    magnificationExperienceForNextLevel = 2;
                }
            }

            else if(playerCurrentLevel > 5)
            {
                if (magnificationExperienceForNextLevel < 5)
                {
                    magnificationExperienceForNextLevel = 5;
                }
            }

            return magnificationExperienceForNextLevel;
        }
    }

    public int MagnificationHealthForNextLevel
    {
        get
        {
            magnificationHealthForNextLevel = ((int)playerMaxHealth * magnificationHealthForNextLevel) / 100;

            if (magnificationHealthForNextLevel < 2)
            {
                magnificationHealthForNextLevel = 2;
            }

            return magnificationHealthForNextLevel;
        }
    }

    int experienceForLevel;

    private int experienceRemainder;

    [SerializeField] int takeExperience;
    public bool PlayerDie { get; set; }

    public bool PlayerAttack { get; set; }
    [SerializeField] float playerMaxHealth;

    [SerializeField] bool playerAirControl;

    //int playerLayerMask, platformLayerMask;

    [SerializeField] EdgeCollider2D playerSwordCollider;

    public EdgeCollider2D PlayerSwordCollider { get => playerSwordCollider;}

    public bool PlayerHit { get; set; }

    public float PlayerMaxHealth { get => playerMaxHealth; set => playerMaxHealth = value; }

    public float Health
    {
        get
        {
            if(health <= 0)
            {
                health = 0;
            }

            else if(health >= PlayerMaxHealth)
            {
                health = PlayerMaxHealth;
            }

            return health;
        }

        private set
        {
            value = health;
        }
    }
        
    public bool PlayerJump { get; set; }

    static Player playerInstance;

    public bool IsFalling
    {
        get
        {
            return PlayerRigidbody.velocity.y < 0;
        }
    }

    public static Player PlayerInstance
    {
        get
        {
            if(playerInstance == null)
            {
                playerInstance = FindObjectOfType<Player>();
            }

            else if(playerInstance != FindObjectOfType<Player>())
            {
                Destroy(playerInstance);
            }

            return playerInstance;
        }
    }

    private float horizontal;

    public Animator PlayerAnimator { get; set; }

    [SerializeField] Transform[] isGround;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask layerMask;

    [SerializeField] int jumpForce;

    public bool PlayerOnGround { get; set; }
    public Rigidbody2D PlayerRigidbody { get; set; }

    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        //playerLayerMask = LayerMask.NameToLayer("Player");
        //platformLayerMask = LayerMask.NameToLayer("Stairs");
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerDie && !PlayerHit)
        {
            PlayerHandleInput();
        }

        //Debug.Log("is falling = " + IsFalling);
        //Debug.Log("rigidbody = " + Player.PlayerInstance.PlayerRigidbody.velocity.y);
        Debug.Log("onGround = " + Player.PlayerInstance.PlayerOnGround);
        //Debug.Log("Jump = " + Player.PlayerInstance.PlayerJump);
    }

    private void FixedUpdate()
    {
        if (!PlayerDie && !PlayerHit)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            PlayerMovement(horizontal);

            Flip(horizontal);

            PlayerOnGround = OnGround();

            CheckLayer();
        }
    }

    private void PlayerMovement(float phorizontal)
    {
        if (IsFalling)
        {
            gameObject.layer = 8;
            PlayerAnimator.SetBool("animatorPlayerJumpDown", true);
        }

        if (!PlayerAttack && (PlayerOnGround || playerAirControl))
        {
            Move(phorizontal);
        }

        if (PlayerJump && PlayerRigidbody.velocity.y == 0 && !IsFalling)
        {
            PlayerRigidbody.AddForce(new Vector2(0, jumpForce));
            //Jump();
        }

        PlayerAnimator.SetFloat("animatorPlayerWalk", Mathf.Abs(phorizontal));
    }
    
    private void PlayerHandleInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //TakeDamage();
            AddIndicatorForPlayer(takeExperience);
            Debug.Log("Fire2");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            PlayerAnimator.SetTrigger("animatorPlayerAttack");
        }

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            //PlayerJump = true;
            //Jump();
            PlayerAnimator.SetTrigger("animatorPlayerJumpUp");
        }

        //if (Input.GetButtonDown("Jump") && !IsFalling && PlayerRigidbody.velocity.y == 0 && PlayerOnGround)
        //{
        //    Jump();
        //    PlayerAnimator.SetTrigger("animatorPlayerJumpUp");
        //}
    }

    private void Move(float mhorizontal)
    {
        PlayerRigidbody.velocity = new Vector2(speed * mhorizontal, PlayerRigidbody.velocity.y);
    }


    //jump
    private void Jump()
    {
        PlayerRigidbody.AddForce(new Vector2(0, jumpForce));
    }


    //player flip
    private void Flip(float fhorizontal)
    {
        if(facingRight && fhorizontal < 0 || !facingRight && fhorizontal > 0)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }

    //check player on ground
    private bool OnGround()
    {
        if (PlayerRigidbody.velocity.y <= 0) 
        {
            foreach (Transform pointOnground in isGround)
            {
                Collider2D[] collider = Physics2D.OverlapCircleAll(pointOnground.position, checkRadius, layerMask);

                for (int i = 0; i < collider.Length; i++)
                {
                    if (collider[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }


    //check layer in animator (PlayerAirLayer)
    private void CheckLayer()
    {
        if (!PlayerOnGround)
        {
            PlayerAnimator.SetLayerWeight(1, 1);
        }

        else 
        {
            PlayerAnimator.SetLayerWeight(1, 0);
        }
    }

    private void TakeDamage()
    {
        if (!PlayerDie)
        {
            PlayerAnimator.SetTrigger("animatorPlayerTakeDamage");
            health -= 5;

            if (health <= 0)
            {
                PlayerAnimator.SetTrigger("animatorPlayerDie");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.GameManagerInstance.CountCoin++;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (listDamageSourceForPlayer.Contains(collision.tag))
        {
            TakeDamage();
        }
    }

    public void PlayerSwoardEnable()
    {
        PlayerSwordCollider.enabled = true;
    }

    //public void PlayerSwoardDisable()
    //{
    //    playerSword.enabled = false;
    //}

    public void AddIndicatorForPlayer(int experience)
    {
        CurrentExperience += experience;

        if(CurrentExperience >= MaxExperienceInCurrentLevel)
        {
            int countUpLevel = (CurrentExperience / MaxExperienceInCurrentLevel);
            for(int countLevel = 0; countLevel < countUpLevel; countLevel++)
            {
                CurrentExperience = Mathf.Abs(CurrentExperience - MaxExperienceInCurrentLevel);

                MaxExperienceInCurrentLevel += MagnificationExperienceForNextLevel;

                playerCurrentLevel++;

                playerMaxHealth += MagnificationHealthForNextLevel;

                health = playerMaxHealth;
            }
        }
    }

    //public void SavePlayer()
    //{
    //    SaveSystem.SavePlayer(this);

    //    Debug.Log("Save");
    //}

    //public void LoadPlayer()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();

    //    health = data.playerHealth;

    //    playerMaxHealth = data.playerMaxHealth;

    //    CurrentExperience = data.playerExperience;

    //    Debug.Log("Load");
    //}
}
