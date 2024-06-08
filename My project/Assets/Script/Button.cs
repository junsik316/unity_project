using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private bool sprint = false;
    private float xmove;
    private float ymove;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xmove = Input.GetAxisRaw("Horizontal");
        ymove = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(xmove ,0, ymove).normalized;
        
        sprint = Input.GetButton("Sprint");
        speed = sprint? speed=20f:speed = 15f;
        transform.position += vec * speed * Time.deltaTime;
        transform.LookAt(transform.position + vec);
        animator.SetBool("inWalk", vec != Vector3.zero);
        animator.SetBool("inRun",sprint);
            
    }
}
