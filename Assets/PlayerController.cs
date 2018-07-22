using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid2D;
    Animator animator;
  

    float jumpForce = 8.0f;
    float runForce = 4.0f;

    bool jump = false;

	// Use this for initialization
	void Start () {

        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && !jump){

            animator.Play("jump");
            rigid2D.velocity = new Vector2(0, jumpForce);
            jump = true;

        }

       //左右の移動
        
        if (Input.GetKey(KeyCode.RightArrow)){

            animator.Play("run");
            rigid2D.velocity = new Vector2(runForce, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow)){

            animator.Play("run");
            rigid2D.velocity = new Vector2(-runForce, GetComponent<Rigidbody2D>().velocity.y);

            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z );

        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")){

            jump = false;
        }
    }
}
