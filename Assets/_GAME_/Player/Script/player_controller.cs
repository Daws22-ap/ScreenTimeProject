using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

[SelectionBase]
public class player_controller : MonoBehaviour
{
    #region
    private enum Direction { UP, DOWN, RIGHT, LEFT};
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
    private Direction _facingDirection = Direction.DOWN;

    private readonly int _animMoveRight = Animator.StringToHash("Anim_Player_Moves_Right");
    private readonly int _animIdleRight = Animator.StringToHash("Anim_Player_Idles_Right");
    private readonly int _animMoveLeft = Animator.StringToHash("Anim_Player_Moves_Left");
    private readonly int _animIdleLeft = Animator.StringToHash("Anim_Player_Idles_Left");
    private readonly int _animMoveUp = Animator.StringToHash("Anim_Player_Moves_Up");
    private readonly int _animIdleUp = Animator.StringToHash("Anim_Player_Idles_Up");
    private readonly int _animMoveDown = Animator.StringToHash("Anim_Player_Moves_Down");
    private readonly int _animIdleDown = Animator.StringToHash("Anim_Player_Idles_Down");

    #endregion

    #region tick
    private void Update()
    {
        gatherInput();
        calculateFacingDirection();
        updateAnimation();
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
    private void calculateFacingDirection()
    {
        if(_moveDir.x != 0)
        {
            if(_moveDir.x > 0) //Moving Right
            {
                _facingDirection = Direction.RIGHT;
            }
            else if (_moveDir.x < 0) //Moving Left
            {
                _facingDirection = Direction.LEFT;
            }
        }else if (_moveDir.y != 0)
        {
            if (_moveDir.y > 0) //Moving Up
            {
                _facingDirection = Direction.UP;
            }
            else if (_moveDir.y < 0) //Moving Down
            {
                _facingDirection = Direction.DOWN;
            }
        }
    }

    private void updateAnimation()
    {
        var isMoving = _moveDir.sqrMagnitude > 0;
        var _targetAnim = _animMoveDown;

        switch (_facingDirection)
        {
            case Direction.UP:
                _targetAnim = isMoving ? _animMoveUp : _animIdleUp;
                break;
            case Direction.DOWN:
                _targetAnim = isMoving ? _animMoveDown : _animIdleDown;
                break;
            case Direction.LEFT:
                _targetAnim = isMoving ? _animMoveLeft : _animIdleLeft;
                break;
            case Direction.RIGHT:
            default:
                _targetAnim = isMoving ? _animMoveRight : _animIdleRight;
                break;
        }

        _animator.CrossFade(_targetAnim, 0);
    }
    #endregion
}
