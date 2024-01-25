using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player instance;
    [Header("Player Settings")]
    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] public float speed = 1f;
    [SerializeField] float dashForce = 2f;
    [SerializeField] GameObject player;

    private Animator _anim;
    private Rigidbody _rigidbody;

    bool isJumping = true;
    bool girado = true;
    Vector3 direction;

    CapsuleCollider capsule;

    [SerializeField] string groundTag = "Ground";
    [SerializeField] string canRotateTag = "CanRotate";
    [SerializeField] string deadZone = "DeadZone";
    [SerializeField] string pursuer = "Pursuer";
    [SerializeField] string enemy = "Enemy";

    [SerializeField] public Vector3 hangPosition;

    public GameObject dieCanva;

    [SerializeField] SoundEffectsPlayer soundEffectsPlayer;

    enum StatesPlayer
    {
        Jump, 
        Rotate, 
        Rope,
    }

    StatesPlayer statesPlayer = StatesPlayer.Jump;

    public void Start()
    {
        direction = Vector3.forward;
        _anim = GetComponentInChildren<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Awake()
    {
        instance = this;
    }
    private void Update()
    {

        Vector3 newVelocity;

        newVelocity = transform.forward * speed;

        newVelocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = newVelocity;


        if (Input.GetMouseButtonDown(0) && statesPlayer == StatesPlayer.Jump && isJumping)
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0) && statesPlayer == StatesPlayer.Rotate)
        {
            Rotate();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Tumble();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Dash();
        }
    }

    private void Jump()
    {
        _anim.SetTrigger("JUMP");
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        isJumping = false;
        _rigidbody.useGravity = true;
        soundEffectsPlayer.Button3();
    }

    private void Rotate()
    {
        if (girado && direction == Vector3.forward)
        {
            direction = Vector3.forward;
            transform.Rotate(Vector3.up, 90f);
            girado = false;
        }
        else
        {
            direction = Vector3.forward;
            transform.Rotate(Vector3.up, -90f);
            girado = true;
        }
    }

    //Aqui hace la voltereta y modifica su capsula collider para esquivar enemigos
    private void Tumble()
    {
        _anim.SetTrigger("TUMBLE");

        Vector3 originalColliderPosition = capsule.center;
        float originalColliderHeight = capsule.height;

        capsule.height = 0.47f;
        capsule.center = new Vector3(capsule.center.x, 0.235f, capsule.center.z);

        StartCoroutine(ResetCollider(originalColliderPosition, originalColliderHeight, 1.0f));
    }

    //Esta corrutina es la que se encarga de volver a su posición original la capsula collider del personaje una vez ha hecho la voltereta
    private IEnumerator ResetCollider(Vector3 originalPosition, float originalHeight, float delay)
    {
        yield return new WaitForSeconds(delay);

        capsule.center = originalPosition;
        capsule.height = originalHeight;
    }

    private void Dash()
    {

        _anim.SetTrigger("DASH");
        _rigidbody.AddForce(transform.forward * dashForce, ForceMode.VelocityChange);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(groundTag))
        {
            statesPlayer = StatesPlayer.Jump;
            isJumping = true;
        }

        if (other.gameObject.CompareTag(canRotateTag))
        {
            statesPlayer = StatesPlayer.Rotate;
        }

        if (other.gameObject.CompareTag(deadZone) || other.gameObject.CompareTag(pursuer) || other.gameObject.CompareTag(enemy))
        {
            ActiveCanva();
            Time.timeScale = 0;
            player.SetActive(false);
        }
    }

    public void ActiveCanva()
    {
        dieCanva.SetActive(true);
    }
}