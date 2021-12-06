using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackBasic")]
    public class AttackBasic : StateData
    {
        public string kind = "basic";
        public float range;
        public AudioClip soundFX;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            control.audio.PlayOneShot(soundFX);
            control.basic.Play();
            RaycastHit hit;

            if (control.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                if (Physics.Raycast(control.fireTransform.position, Vector3.right, out hit, range))
                {
                    var target = hit.transform.GetComponent<EnemyDamage>();
                    if (target != null) target.TakeDamage(kind);
                }
            }
            else
            {
                if (Physics.Raycast(control.fireTransform.position, Vector3.left, out hit, range))
                {
                    var target = hit.transform.GetComponent<EnemyDamage>();
                    if (target != null) target.TakeDamage(kind);
                }
            }
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}