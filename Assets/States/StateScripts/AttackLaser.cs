using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackLaser")]
    public class AttackLaser : StateData
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
            control.laser.Play();
            if (control.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                Debug.DrawRay(control.fireTransform.position, Vector3.right, Color.yellow);
                if (Physics.Raycast(control.fireTransform.position, Vector3.right, out var hit, range))
                {
                    var target = hit.transform.GetComponent<EnemyDamage>();
                    if (target != null) target.TakeDamage(kind);
                }
            }
            else
            {
                Debug.DrawRay(control.fireTransform.position, Vector3.left, Color.yellow);
                if (Physics.Raycast(control.fireTransform.position, Vector3.left, out var hit, range))
                {
                    var target = hit.transform.GetComponent<EnemyDamage>();
                    if (target != null) target.TakeDamage(kind);
                }
            }
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
            animator.SetBool(TransitionParameter.Laser.ToString(), false);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}