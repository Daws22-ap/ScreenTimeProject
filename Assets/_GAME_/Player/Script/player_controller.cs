using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[SelectionBase]
public class player_controller : MonoBehaviour
{
    #region
    private enum Direcrtion { UP, DOWN, RIGHT, LEFT};
    #endregion

    #region Editor Data
    [Header("Movement attributes")]
    [SerializeField] float _moveSpeed = 50f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    #endregion

    #region Internal Data
    private Vector2  _moveDir = Vector2.zero;
    private Direcrtion _facingDirection = Direcrtion.DOWN;
    #endregion

    #region tick
    private void Update()
    {
        gatherInput();
    }

    private void FixedUpdate()
    {
        movementUpdate();
    }
    #endregion

    #region Input Logic
    private void gatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
    }
    #endregion

    #region Movement Logic
    private void movementUpdate()
    {
        _rb.velocity = _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime; 
    }
    #endregion

    #region  Animation Logic

    #endregion
}
