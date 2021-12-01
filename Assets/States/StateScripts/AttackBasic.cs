using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/AttackBasic")]
    public class AttackBasic : StateData
    {
        public GameObject basicProjectile;
        public ParticleSystem basic;
        public float speed;
        public string kind = "basic";
        public float range;
        public AudioClip soundFX;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            basic = animator.gameObject.GetComponentInChildren<ParticleSystem>();
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            RaycastHit hit;

            var control = characterState.GetCharacterControl(animator);
            control.audio.PlayOneShot(soundFX);
            var fireBall = Instantiate(basicProjectile, control.fireTransform);

            if (control.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                fireBall.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
                basic.Emit(1);
                // particle emit
                if (Physics.Raycast(control.fireTransform.position, Vector3.right, out hit, range))
                {
                    Debug.DrawRay(control.fireTransform.position, Vector3.right, Color.black, 10, true);
                    Debug.Log(hit.transform.name);
                    var target = hit.transform.GetComponent<EnemyDamage>();
                    if (target != null) target.TakeDamage(kind);
                }
            }
            else
            {
                fireBall.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
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