using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackSelector")]
    public class AttackSelector : StateData
    {
        public GameObject fireWeapon;
        public GameObject basicWeapon;
        public GameObject empWeapon;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.meleeWeapon.ToString(), true);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            if (control.weaponMelee)
            {
                animator.SetBool(TransitionParameter.meleeWeapon.ToString(), true);
                animator.SetBool(TransitionParameter.fireWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.basicWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.empWeapon.ToString(), false);

                fireWeapon.SetActive(false);
                basicWeapon.SetActive(false);
                empWeapon.SetActive(false);
            }
            if (control.weaponFire && control.hasWeaponFire)
            {
                animator.SetBool(TransitionParameter.meleeWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.fireWeapon.ToString(), true);
                animator.SetBool(TransitionParameter.basicWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.empWeapon.ToString(), false);

                fireWeapon.SetActive(true);
                basicWeapon.SetActive(false);
                empWeapon.SetActive(false);
            }
            if (control.weaponBasic && control.hasWeaponBasic)
            {
                animator.SetBool(TransitionParameter.meleeWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.fireWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.basicWeapon.ToString(), true);
                animator.SetBool(TransitionParameter.empWeapon.ToString(), false);

                fireWeapon.SetActive(false);
                basicWeapon.SetActive(true);
                empWeapon.SetActive(false);
            }
            if (control.weaponEMP && control.hasWeaponEMP)
            {
                animator.SetBool(TransitionParameter.meleeWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.fireWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.basicWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.empWeapon.ToString(), true);

                fireWeapon.SetActive(false);
                basicWeapon.SetActive(false);
                empWeapon.SetActive(true);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}