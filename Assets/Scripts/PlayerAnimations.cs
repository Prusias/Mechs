using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimations : MonoBehaviour {

    public Animator animator;
    public float runningSpeed;
    private bool isRunningRight;
    private bool shouldReset;
    private bool isInAnimation;
    private float animationCount;
    private Vector2 defaultPosition;

	// Use this for initialization
	void Start () {
        animator = GetComponentInParent<Animator>();
        defaultPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        RunRight();
        Reset();
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
            }
        }
        if (!isInAnimation)
        {
            if (shouldReset)
            {
                this.transform.position = defaultPosition;
                shouldReset = false;
            }
        }
	}

    public void RunRight()
    {
        animationCount = 0;
        isRunningRight = true;
        isInAnimation = true;
        animator.SetBool("Run", true);
    }
    public void Reset()
    {
        shouldReset = true;
        
    }
}
