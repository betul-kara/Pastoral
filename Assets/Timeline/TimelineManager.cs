using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    bool fix = false;
    [SerializeField] Animator camAnimator;
    [SerializeField] RuntimeAnimatorController camAnim;
    [SerializeField] PlayableDirector director;

    private void OnEnable()
    {
        camAnim = camAnimator.runtimeAnimatorController;
        camAnimator.runtimeAnimatorController = null;
    }
    private void Update()
    {
        if (director.state != PlayState.Playing && !fix)
        {
            fix = true;
            camAnimator.runtimeAnimatorController = camAnim;
        }
    }
}
