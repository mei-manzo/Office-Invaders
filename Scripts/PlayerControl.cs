using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(CanvasManager))]


public class PlayerControl : MonoBehaviour
{
   private Rigidbody playerRb; 
    public bool isOnGround = true;
  public bool gameOver = false;
   public float jumpForce;
   public float gravityModifier;
    public TextMeshProUGUI gameOverText;

    // private AudioSource playerAudio;
    //public AudioClip FootStep;
    //public AudioClip GunSound;

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        //public bool LockMouse;
    }
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] MouseInput MouseControl;
    [SerializeField] AudioController footSteps;
    [SerializeField] float minimumMoveThreshold;
    private MoveController m_MoveController;
    Vector3 previousPosition;
    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
                m_MoveController = GetComponent<MoveController>();
            return m_MoveController;
        }
    }
    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }
    private PlayerHealth m_PlayerHealth;
    public PlayerHealth PlayerHealth
    {
        get
        {
            if (m_PlayerHealth == null)
                m_PlayerHealth = GetComponent<PlayerHealth>();
            return m_PlayerHealth;

        }
    }

    InputController playerInput;
    Vector2 mouseInput;
    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
       playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //spacebar to jump, need to debug
         {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Debug.Log(" Spacebar is pressed ");

          }*/
      /*  if (PlayerHealth.IsAlive)
            return;*/

        Move();
        LookAround();
       // Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
       


    }

    void Move()
    {
        float moveSpeed = runSpeed;

        Vector2 direction = new Vector2(playerInput.Vertical * runSpeed, playerInput.Horizontal * runSpeed);
        MoveController.Move(direction);

        if (playerInput.IsWalking)
            moveSpeed = walkSpeed;
        if (Vector3.Distance(transform.position, previousPosition) > minimumMoveThreshold)
            footSteps.Play();
        previousPosition = transform.position;

    }

    void LookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
    }

    public void OnTriggerEnter(Collider other)
    {
       /* gameOverText.gameObject.SetActive(true);
        Destroy(gameObject);*/ // ---- makes player disappear upon loading game
      
    }
 //   public void RestartGame()
  /*  {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/


}

