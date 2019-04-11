using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimations : MonoBehaviour {

    public Animator animator;
    public float runningSpeed;
    public bool isRunningRight;
    public bool isRunningLeft;
    public bool isAttacking;
    public bool willAttack;
    public bool isDieing;
    public bool shouldReset;
    public bool isInAnimation;
    public float animationCount;
    private Vector2 defaultPosition;

	// Use this for initialization
	void Start () {
        animator = GetComponentInParent<Animator>();
        defaultPosition = new Vector2(this.transform.position.x, this.transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
		if (isRunningRight)
        {
            if (animationCount < 12)
            {
                this.transform.position = new Vector2(this.transform.position.x + runningSpeed * Time.deltaTime, this.transform.position.y);
                animationCount += runningSpeed * Time.deltaTime;
            } else
            {
                isRunningRight = false;
                isInAnimation = false;
                animator.SetBool("Run", false);
                animationCount = 0;
            }
        }
        if (isRunningLeft)
        {
            if (animationCount < 12)
            {
                this.transform.position = new Vector2(this.transform.position.x - runningSpeed * Time.deltaTime, this.transform.position.y);
                animationCount += runningSpeed * Time.deltaTime;
            }
            else
            {
                isRunningLeft = false;
                isInAnimation = false;
                animator.SetBool("Run", false);
                animationCount = 0;
            }
        }
        if (isDieing)
        {
            if (animationCount < 10)
            {
                animationCount += 10f * Time.deltaTime;
            } else
            {
                isDieing = false;
                isInAnimation = false;
            }
        }

        if (willAttack)
        {
            if (isInAnimation == false)
            {
                animationCount += 1f * Time.deltaTime;
                if (animationCount > 1)
                {
                    isAttacking = true;
                    willAttack = false;
                    isInAnimation = true;
                    animator.SetBool("Attack", true);
                }
            }
           
            
           
            
        }
        if (isAttacking)
        {
            if (animationCount < 6)
            {
                animationCount += 1f * Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                isInAnimation = false;
                animator.SetBool("Attack", false);
            }
        }
        if (!isInAnimation && !willAttack && !isAttacking)
        {
            if (shouldReset)
            {
                this.transform.position = defaultPosition;
                shouldReset = false;
                
            }
        }
	}

    private void RunRight()
    {
        animationCount = 0;
        isRunningRight = true;
        isInAnimation = true;
        animator.SetBool("Run", true);
    }
    private void RunLeft()
    {
        animationCount = 0;
        isRunningRight = true;
        isInAnimation = true;
        animator.SetBool("Run", true);
    }
    public void Die()
    {
        animationCount = 0;
        isDieing = true;
        isInAnimation = true;
        animator.SetBool("Death", true);
    }
    public void AttackRight()
    {
        willAttack = true;
        RunRight();
    }
    public void AttackLeft()
    {
        willAttack = true;
        RunLeft();
    }
    public void Reset()
    {
        shouldReset = true;
        
    }
}
