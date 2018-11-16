using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Animations
{
    public static class AnimationExtensions
    {
        public static AnimationClip GetAnimationClip(this Animator animator,string name)
        {
                if (!animator) return null; // no animator

                foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
                {
                    if (clip.name == name)
                    {
                        return clip;
                    }
                }
                return null; // no clip by that name
            }
    }
}
