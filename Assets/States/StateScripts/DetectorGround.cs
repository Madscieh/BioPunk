using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/DetectorGround")]
    public class DetectorGround : StateData
    {
        [Range(0.01f, 1f)] public float checkTime;
        public float groundDistance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (stateInfo.normalizedTime >= checkTime) animator.SetBool(TransitionParameter.isGrounded.ToString(), IsGrounded(control));
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        private bool IsGrounded(CharacterControl control)
        {
            if (control.Rigidbody.velocity.y > -0.001f && control.Rigidbody.velocity.y <= 0f) return true;
            if (control.Rigidbody.velocity.y < 0f && Physics.Raycast(control.transform.position, Vector3.down, groundDistance)) return true;
            return false;
        }
    }
}