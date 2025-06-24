using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[SelectionBase]
public class player_controller : MonoBehaviour
{

    #region Editor Data
    [Header("Movement attributes")]
    [SerializeField] float _moveSpeed = 50f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    #endregion

    #region Internal Data
    private Vector2  _moveDir = Vector2.zero;
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

        print(_moveDir);
    }
    #endregion

    #region Movement Logic
    private void movementUpdate()
    {
        _rb.velocity = _moveDir * _moveSpeed * Time.fixedDeltaTime; 
    }
    #endregion

}
