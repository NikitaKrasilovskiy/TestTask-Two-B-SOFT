using UnityEngine;
using UnityEngine.UI;

public class ClickAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    { animator = GetComponent<Animator>(); }
    public void Click()
    { animator.SetTrigger("Go"); }
    public void ClickPlay()
    { animator.SetFloat("Play",+1); }
    public void ClickRepear()
    { animator.SetFloat("Play",-1); }
}
