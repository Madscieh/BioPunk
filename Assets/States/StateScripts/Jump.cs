using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float jumpForce;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.isJumping.ToString(), false);
            characterState.GetCharacterControl(animator).Rigidbody.AddForce(Vector3.up * jumpForce);
            animator.SetBool(TransitionParameter.isGrounded.ToString(), false);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}