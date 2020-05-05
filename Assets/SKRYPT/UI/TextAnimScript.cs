using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimScript : MonoBehaviour
{
    private Animator animator;
    private void OnEnable()
    {
        animator.SetTrigger("enabled");
    }
}
