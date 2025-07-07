using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair1 : MonoBehaviour, IInteractable
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnInteract()
    {
        animator.SetTrigger("i1");
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public string Infor()
    {
        return "Dựng ghế";
    }
}
