using UnityEngine;
using UnityEngine.UI;

public class AnimIsPlaying : MonoBehaviour
{
    public Button buttonBack;
    public Animator[] animator;
    private void Update()
    {
        if (animator[0].GetCurrentAnimatorStateInfo(0).normalizedTime < 1 ||
            animator[1].GetCurrentAnimatorStateInfo(0).normalizedTime < 1 ||
            animator[2].GetCurrentAnimatorStateInfo(0).normalizedTime < 1 ||
            animator[3].GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        { buttonBack.interactable = false; }
        else buttonBack.interactable = true;
    }
}
