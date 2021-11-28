using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/DetectorWall")]
    public class DetectorWall : StateData
    {
        [Range(0.01f, 1f)] public float checkTime;
        public float blockDistance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            if (stateInfo.normalizedTime >= checkTime) animator.SetBool(TransitionParameter.isAgainstWall.ToString(), CheckFront(control));
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