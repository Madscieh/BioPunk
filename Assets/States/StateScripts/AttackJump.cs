using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackJump")]
    public class AttackJump : StateData
    {
        public string kind = "melee";
        public float range;
        public AudioClip soundFX;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            control.audio.PlayOneShot(soundFX);
            if (Physics.Raycast(control.fireTransform.position, Vector3.down, out var hit, range))
            {
                var target = hit.transform.GetComponent<EnemyDamage>();
                if (target != null) target.TakeDamage(kind);
            }
            animator.SetBool(TransitionParameter.isJumping.ToString(), false);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}