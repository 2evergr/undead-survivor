using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    [SerializeField]
    float speed;

    void Awake()
    {
       rigid = GetComponent<Rigidbody2D>();
       spriter = GetComponent<SpriteRenderer>();
       anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     inputVec.x = Input.GetAxisRaw("Horizontal");
    //     inputVec.y = Input.GetAxisRaw("Vertical");

    //     if (inputVec.x < 0) {
    //         sprite.flipX = true;
    //     } else if (inputVec.x > 0) {
    //         sprite.flipX = false;
    //     }
    // }

    void FixedUpdate()
    {
        // rigid.AddForce(inputVec);
        // rigid.velocity = inputVec;
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
