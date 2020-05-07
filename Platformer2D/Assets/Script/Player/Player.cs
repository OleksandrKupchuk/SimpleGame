using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : CharacterBase
{
    [SerializeField] SoundManager soundManager;

    private IUsable usable;
    //[SerializeField] InventoryUI invenroryUI;

    [SerializeField] GameObject shieldPrefab;
    [SerializeField] Transform shieldPointStart;

    public bool shieldDie = false;

    [SerializeField] List<string> listDamageSourceForPlayer;

    [SerializeField] public int playerCurrentLevel;

    public bool PlayerBlink { get; set; }
    [SerializeField] float playerDelayBlink;

    //player experience;
    [SerializeField] private int playerCurrentExperience;

    public int PlayerCurrentExperience
    {
        get => playerCurrentExperience; set => playerCurrentExperience = value;
    }

    [SerializeField] int maxExperienceInCurrentLevel;

    public int MaxExperienceInCurrentLevel
    {
        get => maxExperienceInCurrentLevel; set => maxExperienceInCurrentLevel = value;
    }

    [SerializeField] int interestExperienceForNextLevel;
    [SerializeField] int interestHealthForNextLevel;

    public int InterestExperienceForNextLevel 
    { 
        get
        {
            interestExperienceForNextLevel = (maxExperienceInCurrentLevel * interestExperienceForNextLevel) / 100;

            if (playerCurrentLevel <= 5)
            {
                if (interestExperienceForNextLevel < 2)
                {
                    interestExperienceForNextLevel = 2;
                }
            }

            else if(playerCurrentLevel > 5)
            {
                if (interestExperienceForNextLevel < 5)
                {
                    interestExperienceForNextLevel = 5;
                }
            }

            return interestExperienceForNextLevel;
        }
    }

    public int InterestHealthForNextLevel
    {
        get
        {
            interestHealthForNextLevel = ((int)maxHealth * interestHealthForNextLevel) / 100;

            if (interestHealthForNextLevel < 2)
            {
                interestHealthForNextLevel = 2;
            }

            return interestHealthForNextLevel;
        }
    }

    [SerializeField] int takeExperience;
    public bool PlayerDie { get; set; }

    public bool PlayerAttack { get; set; }

    [SerializeField] bool playerAirControl;

    [SerializeField] EdgeCollider2D playerSwordCollider;

    public EdgeCollider2D PlayerSwordCollider { get => playerSwordCollider;}

    public bool PlayerBlock { get; set; }

    public bool PlayerHit { get; set; }

    public float PlayerMaxHealth { get => maxHealth; set => maxHealth = value; }

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

    public float Horizontal { get => horizontal;}

    public Animator PlayerAnimator { get; set; }

    [SerializeField] Transform[] isGround;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask layerMask;

    [SerializeField] int jumpForce;

    public bool PlayerOnGround { get; set; }
    public Rigidbody2D PlayerRigidbody { get; set; }

    [SerializeField] SpriteRenderer playerSpriteRenderer;

    public override void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!PlayerDie && !PlayerHit)
        {
            PlayerHandleInput();
        }

        //Debug.Log("horiz = " + Player.PlayerInstance.Horizontal);
        //Debug.Log("ground = " + PlayerOnGround);
        //Debug.Log("Right = " + facingRight);
        //Debug.Log("Block = " + PlayerBlock);
        //Debug.Log("is falling = " + IsFalling);
        //Debug.Log("rigidbody = " + PlayerRigidbody.velocity.y);
        //Debug.Log("onGround = " + Player.PlayerInstance.PlayerOnGround);
        //Debug.Log("Jump = " + Player.PlayerInstance.PlayerJump);
    }

    private void FixedUpdate()
    {
        if (!PlayerDie && !PlayerHit)
        {
            if (!PlayerBlock)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
            }

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
            //gameObject.layer = 8;
            PlayerAnimator.SetBool("animatorPlayerJumpDown", true);
        }

        if (!PlayerAttack && !PlayerBlock && (PlayerOnGround || playerAirControl))
        {
            Move(phorizontal);
        }

        if (PlayerJump && PlayerRigidbody.velocity.y == 0 && !IsFalling)
        {
            PlayerRigidbody.AddForce(new Vector2(0, jumpForce));
            //Jump();
        }

        if (PlayerOnGround)
        {
            PlayerAnimator.SetFloat("animatorPlayerWalk", Mathf.Abs(phorizontal));
        }

        if (!PlayerOnGround)
        {
            PlayerAnimator.SetFloat("animatorPlayerWalk", 0);
        }
    }
    
    //method responsible for input player
    private void PlayerHandleInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteractionWithTheSabject();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            PlayerBlink = true;
            StartCoroutine(PlayerBlinkMethod());
        }

        if (Input.GetButtonDown("Fire2"))
        {
            TakeDamage();
            if (PlayerOnGround && !PlayerJump)
            {
                //TakeDamage();
                AddIndicatorForPlayer(takeExperience);

                PlayerAnimator.SetBool("animatorPlayerShield", true);
                SpawnShield();
            }

        }

        if (Input.GetButtonUp("Fire2"))
        {
            if (PlayerOnGround && !PlayerJump)
            {
                PlayerAnimator.SetBool("animatorPlayerShield", false);
            }
        }

        if (Input.GetButtonDown("Fire1"))//&& !invenroryUI.IsElemtntUI
        {
            PlayerAnimator.SetTrigger("animatorPlayerAttack");
        }

        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jump");
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
        //SoundManager.soundManagerInstance.PlaySound("PlayerRun");
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

    //method is responsible for taking damage, start blinking, and running animation death
    private IEnumerator TakeDamage()
    {
        if (!PlayerBlink)
        {
            if (!PlayerDie)
            {
                PlayerAnimator.SetTrigger("animatorPlayerTakeDamage");
                PlayerBlink = true;

                health -= 5;

                StartCoroutine(PlayerBlinkMethod());
                yield return new WaitForSeconds(playerDelayBlink);

                PlayerBlink = false;

                if (health <= 0)
                {
                    PlayerAnimator.SetTrigger("animatorPlayerDie");
                }
            }
        }
    }

    private IEnumerator PlayerBlinkMethod()
    {
        while (PlayerBlink)
        {
            playerSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            playerSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.GameManagerInstance.CountCoin++;
            SoundManager.soundManagerInstance.PlaySound("PlayerPickUpCoin");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (listDamageSourceForPlayer.Contains(collision.tag))
        {
            StartCoroutine(TakeDamage());
        }

        if (collision.gameObject.CompareTag("Chest"))
        {
            usable = collision.GetComponent<IUsable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            usable = null;
        }
    }

    public void PlayerInteractionWithTheSabject()
    {
        if(usable != null)
        {
            usable.Interaction();
        }
    }

    public void PlayerSwoardEnable()
    {
        PlayerSwordCollider.enabled = true;
    }

    private void SpawnShield()
    {
        if (facingRight)
        {
            Instantiate(shieldPrefab, shieldPointStart.transform.position, Quaternion.identity);
        }

        else
        {
            Instantiate(shieldPrefab, shieldPointStart.transform.position, Quaternion.Euler(new Vector3(0f, 180f, 0f)));
        }
    }

    /// <summary>
    /// enhancing player characteristics at a new level
    /// </summary>
    /// <param name="experience"></param>
    public void AddIndicatorForPlayer(int experience)
    {
        PlayerCurrentExperience += experience;

        if(PlayerCurrentExperience >= MaxExperienceInCurrentLevel)
        {
            int countUpLevel = (PlayerCurrentExperience / MaxExperienceInCurrentLevel);
            for(int countLevel = 0; countLevel < countUpLevel; countLevel++)
            {
                PlayerCurrentExperience = Mathf.Abs(PlayerCurrentExperience - MaxExperienceInCurrentLevel);

                MaxExperienceInCurrentLevel += InterestExperienceForNextLevel; ////add maxexperience on current level on a certain percentage

                PlayerLevelUp();

                maxHealth += InterestHealthForNextLevel; //add health on a certain percentage

                health = maxHealth;
            }
        }
    }

    private void PlayerLevelUp()
    {
        SoundManager.soundManagerInstance.PlaySound("PlayerLevelUp");
        playerCurrentLevel++;
    }
}
