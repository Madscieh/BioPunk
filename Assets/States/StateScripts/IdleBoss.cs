using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/Idle")]
    public class IdleBoss : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.isJumping.ToString(), false);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            if (control.MoveRight) animator.SetBool(TransitionParameter.isRunning.ToString(), true);
            if (control.MoveLeft) animator.SetBool(TransitionParameter.isRunning.ToString(), true);
            if (control.Jump) animator.SetBool(TransitionParameter.isJumping.ToString(), true);
            if (control.Attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
                var kind = Random.Range(1, 5);
                if (kind == 1)
                {
                    animator.SetBool(TransitionParameter.Juggernaut.ToString(), true);
                }
                if (kind == 2)
                {
                    animator.SetBool(TransitionParameter.JumpAttack.ToString(), true);
                }
                if (kind == 3)
                {
                    animator.SetBool(TransitionParameter.Laser.ToString(), true);
                }
                if (kind == 4)
                {
                    animator.SetBool(TransitionParameter.BossMelee.ToString(), true);
                }
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}