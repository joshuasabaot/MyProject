using System.Collections;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class LevelUpPlayer : MonoBehaviour
{
    public VisualEffect vfx;
    
    public float animationTime = 6.3f;


    [SerializeField]private bool inProgress;
    private InputAction levelUp;
    private Animator anim;


    void Start()
    {
        levelUp = InputSystem.actions.FindAction("Jump");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(levelUp.IsPressed() && inProgress == false)
        {
            StartCoroutine(PlayLevelUp(animationTime));
        }
    }

    IEnumerator PlayLevelUp(float animtime)
    {
        inProgress = true;
        anim.SetTrigger("Level Up");
        vfx.Play();
        yield return new WaitForSeconds(animtime-1.2f);
        vfx.Stop();
        yield return new WaitForSeconds(1.2f);
        inProgress = false;
    }




}
