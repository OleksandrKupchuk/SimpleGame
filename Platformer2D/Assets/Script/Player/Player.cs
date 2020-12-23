using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : CharacterBase
{
    private IUsable usable;
    [SerializeField] private ObjectdataLoad data;

    [Header("Player Components")]
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] Transform shieldPointStart;
    [SerializeField] private SourceDamage sourceDamage;
    private GameObject pauseMenu;

    [Header("Player parametrs")]
    public int indexScene;
    public bool shieldDie = false;
    public int playerCurrentLevel;
    [SerializeField] private float playerDelayBlink;
    [SerializeField] private int playerCurrentExperience; //player experience;
    [SerializeField] private int interestExperienceForNextLevel;
    [SerializeField] private int interestHealthForNextLevel;

    public bool PlayerBlink { get; set; }

    public int PlayerCurrentExperience
    {
        get => playerCurrentExperience; set => playerCurrentExperience = value;
    }

    [SerializeField] int playerMaxExperienceInCurrentLevel;

    public int PlayerMaxExperienceInCurrentLevel
    {
        get => playerMaxExperienceInCurrentLevel; set => playerMaxExperienceInCurrentLevel = value;
    }

    public int InterestExperienceForNextLevel 
    { 
        get
        {
            interestExperienceForNextLevel = (playerMaxExperienceInCurrentLevel * interestExperienceForNextLevel) / 100;

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

    [SerializeField] private int interestHealth;

    public int InterestHealthForNextLevel
    {
        get
        {
            interestHealthForNextLevel = ((int)maxHealth * interestHealth) / 100;

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
            return health;
        }

        set
        {
            health = value;

            if (health <= 0)
            {
                health = 0;
            }

            if (health >= PlayerMaxHealth)
            {
                health = PlayerMaxHealth;
            }
        }
    }
        
    public bool PlayerJump { get; set; }
    private float bufferingJumpPressRemember;
    [SerializeField] private float bufferingJumpPressRememberTime;

    static Player playerInstance;

    public bool IsFalling
    {
        get
        {
            return PlayerRigidbody.velocity.y < -0.01;
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

    [SerializeField] private float heightBoxCast;
    [SerializeField] private BoxCollider2D playerBoxCollider2d;
    [SerializeField] private LayerMask layerMask;

    public int jumpForce;

    public bool PlayerOnGround { get; private set; }
    public Rigidbody2D PlayerRigidbody { get; set; }

    [SerializeField] SpriteRenderer playerSpriteRenderer;

    public override void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(3).transform.GetChild(0).gameObject;
        data.LoadPlayer();

        PlayerAnimator = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        GetCurrentIndexScene();
    }

    void Update()
    {
        if (!PlayerDie && !PlayerHit)
        {
            if (pauseMenu.activeSelf == false)
            {
                PlayerHandleInput();
            }
        }

        bufferingJumpPressRemember -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!PlayerDie && !PlayerHit)
        {
            #region Перевірка зіткнення із землею через BoxCast
            RaycastHit2D playerOnGround = Physics2D.BoxCast(playerBoxCollider2d.bounds.center, playerBoxCollider2d.bounds.size, 0f, Vector2.down, heightBoxCast, layerMask);

            Color colorLine;
            if(playerOnGround.collider != null)
            {
                colorLine = Color.blue;
            }

            else
            {
                colorLine = Color.red;
            }

            Debug.DrawRay(playerBoxCollider2d.bounds.center + new Vector3(playerBoxCollider2d.bounds.extents.x, 0), Vector2.down * (playerBoxCollider2d.bounds.extents.y + heightBoxCast), colorLine);
            //Debug.DrawRay(playerBoxCollider2d.bounds.center + new Vector3(playerBoxCollider2d.bounds.extents.x, 0), Vector2.down * (playerBoxCollider2d.bounds.extents.y + distacneBoxCast), colorLine);
            Debug.DrawRay(playerBoxCollider2d.bounds.center - new Vector3(playerBoxCollider2d.bounds.extents.x, 0), Vector2.down * (playerBoxCollider2d.bounds.extents.y + heightBoxCast), colorLine);
            Debug.DrawRay(playerBoxCollider2d.bounds.center - new Vector3(playerBoxCollider2d.bounds.extents.x, playerBoxCollider2d.bounds.extents.y + heightBoxCast), Vector2.right * (playerBoxCollider2d.bounds.size.x), colorLine);

            #endregion

            //check player on ground
            //playerOnGround = Physics2D.OverlapCircle(playerGround.position, checkRadius, layerMask);

            if (!PlayerBlock)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
            }

            PlayerMovement(horizontal);

            Flip(horizontal);

            PlayerOnGround = playerOnGround;

            CheckLayer();
        }
    }

    private void PlayerMovement(float phorizontal)
    {
        if (IsFalling)
        {
            PlayerAnimator.SetBool("animatorPlayerJumpDown", true);
            PlayerRigidbody.gravityScale = 5;
        }

        if (!PlayerAttack && !PlayerBlock && (PlayerOnGround || playerAirControl))
        {
            Move(phorizontal);
        }

        #region варіації перевірки стрибка
        //if (PlayerJump && PlayerRigidbody.velocity.y == 0)
        //{
        //    Jump();
        //}

        if (PlayerOnGround && (bufferingJumpPressRemember > 0))
        {
            Jump();
        }

        //if (PlayerJump && PlayerOnGround)
        //{
        //    Jump();
        //}
        #endregion

        if (PlayerOnGround)
        {
            PlayerRigidbody.gravityScale = 2;
            PlayerAnimator.SetFloat("animatorPlayerWalk", Mathf.Abs(phorizontal));
        }

        if (!PlayerOnGround && !IsFalling)
        {
            PlayerAnimator.SetFloat("animatorPlayerWalk", 0);
            PlayerAnimator.SetTrigger("animatorPlayerJumpUp");
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
            //TakeDamage(2);
            if (PlayerOnGround && !PlayerJump)
            {
                //TakeDamage();
                Debug.Log("shok");
                AddIndicatorForPlayer(10);

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

        if (Input.GetButtonDown("Fire1") && PlayerOnGround)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                PlayerAnimator.SetTrigger("animatorPlayerAttack");
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            bufferingJumpPressRemember = bufferingJumpPressRememberTime;
            PlayerAnimator.SetTrigger("animatorPlayerJumpUp");
        }
    }

    private void Move(float mhorizontal)
    {
        PlayerRigidbody.velocity = new Vector2(speed * mhorizontal, PlayerRigidbody.velocity.y);
    }


    //jump
    private void Jump()
    {
        SoundManager.soundManagerInstance.PlaySound("Player_Jump");
        PlayerRigidbody.velocity = Vector2.up * jumpForce;
    }


    //player flip
    private void Flip(float fhorizontal)
    {
        if(facingRight && fhorizontal < 0 || !facingRight && fhorizontal > 0)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
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
    public IEnumerator TakeDamage(float damage)
    {
        if (!PlayerBlink)
        {
            if (!PlayerDie)
            {
                PlayerAnimator.SetTrigger("animatorPlayerTakeDamage");
                PlayerBlink = true;

                Health -= damage;

                StartCoroutine(PlayerBlinkMethod());
                yield return new WaitForSeconds(playerDelayBlink);

                PlayerBlink = false;

                if (Health <= 0)
                {
                    StartCoroutine(GameOver());
                }
            }
        }
    }

    private IEnumerator GameOver()
    {
        PlayerDie = true;
        PlayerAnimator.SetTrigger("animatorPlayerDie");

        PlayerRigidbody.gravityScale = 0;
        gameObject.layer = 23;

        SoundManager.soundManagerInstance.PlaySound("GameOver");
        PlayerRigidbody.velocity = Vector2.zero;

        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(4f);

        SoundManager.soundManagerInstance.StopPlaySound("GameOver");
        SceneManager.LoadScene(currentIndexScene);

        yield return null;
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
            //Debug.Log("Coin");
            GameManager.GameManagerInstance.CountCoin++;
            SoundManager.soundManagerInstance.PlaySound("PlayerPickUpCoin");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Particle"))
        {
            StartCoroutine(TakeDamage(2));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sourceDamage.sourceDamage.Contains(collision.tag))
        {
            if(collision.gameObject.GetComponent<EnemyDamage>() == null)
            {
                Debug.LogError("Посилання на об'єкт не знайдено, або об'єкт не містить потрібний елемент");
            }
            else
            {
                StartCoroutine(TakeDamage(collision.gameObject.GetComponent<EnemyDamage>().damage));
            }
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            StartCoroutine(GameOver());
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

        if(PlayerCurrentExperience >= PlayerMaxExperienceInCurrentLevel)
        {
            int countUpLevel = (PlayerCurrentExperience / PlayerMaxExperienceInCurrentLevel);
            for(int countLevel = 0; countLevel < countUpLevel; countLevel++)
            {
                PlayerCurrentExperience = Mathf.Abs(PlayerCurrentExperience - PlayerMaxExperienceInCurrentLevel);

                PlayerMaxExperienceInCurrentLevel += InterestExperienceForNextLevel; ////add maxexperience on current level on a certain percentage

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

    public void GetCurrentIndexScene()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("scene index = " + indexScene);
    }
}
