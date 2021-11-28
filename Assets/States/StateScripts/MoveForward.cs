using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        //public AnimationCurve SpeedGraph;
        public float speed;
        public float blockDistance;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);

            if (control.Jump) animator.SetBool(TransitionParameter.isJumping.ToString(), true);

            if (control.MoveRight && control.MoveLeft) animator.SetBool(TransitionParameter.isRunning.ToString(), false);
            if (!control.MoveRight && !control.MoveLeft) animator.SetBool(TransitionParameter.isRunning.ToString(), false);
            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (!CheckFront(control)) control.GetComponent<Rigidbody>().velocity = new Vector3(speed, control.GetComponent<Rigidbody>().velocity.y, 0f);
            }
            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f,180f,0f);
                if (!CheckFront(control)) control.GetComponent<Rigidbody>().velocity = new Vector3(-speed, control.GetComponent<Rigidbody>().velocity.y, 0f);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFront(CharacterControl control)
        {
            if (Physics.Raycast(control.transform.position, Vector3.right, blockDistance) && control.MoveRight) return true;
            if (Physics.Raycast(control.transform.position, Vector3.left, blockDistance) && control.MoveLeft) return true;
            return false;
        }
    }
}
