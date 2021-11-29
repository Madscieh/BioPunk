using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackFire")]
    public class AttackFire : StateData
    {
        public ParticleSystem flames;
        //public GameObject fireProjectile;
        public AudioClip soundFX;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            control.audio.PlayOneShot(soundFX);
            var fire = Instantiate(flames, control.firePosition);
            fire.Play();
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}