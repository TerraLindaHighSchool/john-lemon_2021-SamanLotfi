using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 mveDirction;
    private Quaternion rotation;
    private bool isWalking;

    [SerializeField] private float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection.Set(horizontal, 0f, vertical);
        moveDirection.Normalize();

        isWalking = !(Mathf.Approximately(horizontal, 0f));
        animator.SetBool("IsWalking", isWalking);

        Vector3 desiredDirection = Vector3.RotateTowards(transform.position, moveDirection, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
