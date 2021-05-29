using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public float speed;
    public float gravity = -19.81f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float PlayerSpeed;
    private Vector3 movePlayer;
    private Vector3 PlayerInput;
    public bool canMove;
    public GameObject camara;
    public Camera PixelCamera;
    Vector3 velocity;
    GameObject playerCharacter;
    LevelLoader battleLoader;


    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        camara = GameObject.Find("Camera");
        PixelCamera = FindObjectOfType<Camera>();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        battleLoader = FindObjectOfType<LevelLoader>();
    }

    void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            PlayerInput = new Vector3(horizontal, 0, vertical);
            PlayerInput = Vector3.ClampMagnitude(PlayerInput, 1);

            controller.Move(movePlayer * PlayerSpeed * Time.deltaTime);

            SetGravity();

            Vector3 direction = new Vector3(-horizontal, 0f, -vertical).normalized;

            velocity.y += gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (SceneManager.GetActiveScene().name.Equals("Pirate"))
                {
                    battleLoader.LoadSpainScene();
                }

                if (SceneManager.GetActiveScene().name.Equals("Spain"))
                {
                    battleLoader.LoadPirateScene();
                }
            }

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
                if (anim != null)
                {
                    anim.SetBool("Run", true);
                }
            }
            else
            {
                if (anim != null)
                {
                    anim.SetBool("Run", false);
                }
            }

            void SetGravity()
            {
                controller.SimpleMove(Physics.gravity);
            }
        }
    }
    public void setCanMove(bool flag)
    {
        canMove = flag;
    }
}
