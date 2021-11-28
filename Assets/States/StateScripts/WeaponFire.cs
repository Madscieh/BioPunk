using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/WeaponFire")]
    public class WeaponFire : StateData
    {
        public GameObject fireProjectile;
        public float fireBallSpeed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            if (control.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                var fireBall = Instantiate(fireProjectile, control.firePosition);
                fireBall.GetComponent<Rigidbody>().velocity = Vector3.right * fireBallSpeed;
            }
            else
            {
                var fireBall = Instantiate(fireProjectile, control.firePosition);
                fireBall.GetComponent<Rigidbody>().velocity = Vector3.left * fireBallSpeed;
            }
            animator.SetBool(TransitionParameter.WeaponFire.ToString(), false);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}