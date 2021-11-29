using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackSelector")]
    public class AttackSelector : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
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

                control.fireWeapon.SetActive(false);
                control.basicWeapon.SetActive(false);
                control.empWeapon.SetActive(false);
            }
            if (control.weaponFire && control.hasWeaponFire)
            {
                animator.SetBool(TransitionParameter.meleeWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.fireWeapon.ToString(), true);
                animator.SetBool(TransitionParameter.basicWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.empWeapon.ToString(), false);

                control.fireWeapon.SetActive(true);
                control.basicWeapon.SetActive(false);
                control.empWeapon.SetActive(false);
            }
            if (control.weaponBasic && control.hasWeaponBasic)
            {
                animator.SetBool(TransitionParameter.meleeWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.fireWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.basicWeapon.ToString(), true);
                animator.SetBool(TransitionParameter.empWeapon.ToString(), false);

                control.fireWeapon.SetActive(false);
                control.basicWeapon.SetActive(true);
                control.empWeapon.SetActive(false);
            }
            if (control.weaponEMP && control.hasWeaponEMP)
            {
                animator.SetBool(TransitionParameter.meleeWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.fireWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.basicWeapon.ToString(), false);
                animator.SetBool(TransitionParameter.empWeapon.ToString(), true);

                control.fireWeapon.SetActive(false);
                control.basicWeapon.SetActive(false);
                control.empWeapon.SetActive(true);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}