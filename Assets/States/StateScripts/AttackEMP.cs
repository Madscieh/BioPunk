using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackEMP")]
    public class AttackEMP : StateData
    {
        public GameObject empProjectile;
        public float speed;
        public string kind = "emp";
        public float range;
        public AudioClip soundFX;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            RaycastHit hit;

            var control = characterState.GetCharacterControl(animator);
            if (control.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                control.audio.PlayOneShot(soundFX);
                var ball = Instantiate(empProjectile, control.fireTransform);
                ball.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
                if (Physics.Raycast(control.fireTransform.position, Vector3.right, out hit, range))
                {
                    var target = hit.transform.GetComponent<EnemyDamage>();
                    if (target != null)
                    {
                        target.TakeDamage(kind);
                    }
                }
            }
            else
            {
                control.audio.PlayOneShot(soundFX);
                var ball = Instantiate(empProjectile, control.fireTransform);
                ball.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
                if (Physics.Raycast(control.fireTransform.position, Vector3.left, out hit, range))
                {
                    var target = hit.transform.GetComponent<EnemyDamage>();
                    if (target != null)
                    {
                        target.TakeDamage(kind);
                    }
                }
            }
            animator.SetBool(TransitionParameter.Attack.ToString(), false);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}