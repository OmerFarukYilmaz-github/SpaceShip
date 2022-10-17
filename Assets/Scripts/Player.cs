using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    public void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    public void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
           Vector3 delta = rawInput * movementSpeed * Time.deltaTime;
           Vector2 newPos = new Vector2();
           newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x+paddingLeft , maxBounds.x-paddingRight);
           newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y+paddingBottom, maxBounds.y-paddingTop);
           transform.position = newPos;
    }

    public void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
      
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }


}
