using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackEMP")]
    public class AttackEMP : StateData
    {
        public GameObject empProjectile;
        public float speed;
        public AudioClip soundFX;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            if (control.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                control.audio.PlayOneShot(soundFX);
                var fireBall = Instantiate(empProjectile, control.firePosition);
                fireBall.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
            else
            {
                control.audio.PlayOneShot(soundFX);
                var fireBall = Instantiate(empProjectile, control.firePosition);
                fireBall.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}