using System;
using General;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class PlayerController : SingletonMonoBehavior<PlayerController>
    {
        private MyInputActions _inputActions;
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField] private Animator animator;
        [SerializeField] private float moveSpeed;

        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private Vector3 _moveDir = Vector3.zero;
        // Start is called before the first frame update
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _inputActions = new MyInputActions();
            _inputActions.Enable();
            _inputActions.Player.Move.started += Player_Move_Started;
            _inputActions.Player.Move.performed += Player_Move_Performed;
            _inputActions.Player.Move.canceled += Player_Move_Canceled;
            animator = GetComponentInChildren<Animator>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        

        private void Player_Move_Started(InputAction.CallbackContext obj)
        {
            Debug.Log("Started");
            animator.SetBool("isWalking", false);
        }

       private void Player_Move_Performed(InputAction.CallbackContext obj)
       { 
           Debug.Log("Performed");
           _moveDir = obj.ReadValue<Vector2>();
           animator.SetBool("isWalking", true);

       }
       private void Player_Move_Canceled(InputAction.CallbackContext obj)
       { 
           Debug.Log("Canceled");
           _moveDir = Vector3.zero;
           animator.SetBool("isWalking", false);
       }

       private void FixedUpdate()
       {
           transform.position += _moveDir.normalized * (Time.deltaTime * moveSpeed);
           spriteRenderer.flipX = _moveDir.x < 0;
       }
    }
}
