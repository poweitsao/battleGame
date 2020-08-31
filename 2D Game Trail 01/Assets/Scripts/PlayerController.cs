using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;

    private PlayerControls playerControls;

    private Rigidbody2D rb;

    private Collider2D col;

    private Animator animator;

    private SpriteRenderer spriteRenderer;


    private void Awake() {
      playerControls = new PlayerControls();
      rb = GetComponent<Rigidbody2D>();
      col = GetComponent<Collider2D>();
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
      playerControls.Enable();
    }

    private void OnDisable() {
      playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // Character's movement controls
      Move();
    }

    private void Move() {
      // Read the movement value
      float movementInput = playerControls.Player.Movement.ReadValue<float>();

      // Move the player
      Vector3 currentPosition = transform.position;
      currentPosition.x += movementInput * speed * Time.deltaTime;
      transform.position = currentPosition;

      // Animation
      if (movementInput != 0) animator.SetBool("Run", true);
      else animator.SetBool("Run", false);

      // Sprite Flip
      if (movementInput == -1)
        spriteRenderer.flipX = true;
      else if (movementInput == 1)
        spriteRenderer.flipX = false;
    }

}
