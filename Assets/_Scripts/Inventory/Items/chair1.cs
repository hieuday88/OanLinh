using UnityEngine;

public class chair1 : MonoBehaviour, IInteractable, ISaveable
{
    private Animator animator;
    private bool isUpright = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnInteract()
    {
        if (!isUpright)
        {
            animator.SetTrigger("i1");
            gameObject.layer = 0;
            isUpright = true;
        }
    }

    public string Infor()
    {
        return "Dựng ghế";
    }


    [System.Serializable]
    public struct ChairState
    {
        public bool isUpright;
    }

    public object CaptureState()
    {
        return new ChairState
        {
            isUpright = this.isUpright
        };
    }


    public void RestoreState(object state)
    {
        ChairState saved = (ChairState)state;
        this.isUpright = saved.isUpright;

        if (isUpright)
        {
            animator.SetTrigger("i1");
            gameObject.layer = 0;
        }
    }
}
