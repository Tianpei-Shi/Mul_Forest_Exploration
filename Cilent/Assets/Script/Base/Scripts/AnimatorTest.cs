using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    private Animator animator;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("left");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            animator.Play("right");
        }
    }
}
