using UnityEngine;

namespace BioPunk
{
    public class EnemyAI : MonoBehaviour
    {
        public CharacterControl characterControl;
        public Transform player;
        public float distanceToPursue;
        public float distanceToAttack;
        public float firingInterval;
        private float _firingTime = 0f;

        private void Update()
        {
            if (Vector3.Distance(player.position, transform.position) <= distanceToPursue)
            {
                if (Vector3.Distance(player.position, transform.position) <= distanceToAttack)
                {
                    if (Time.time > _firingTime)
                    {
                        _firingTime = Time.time + firingInterval;
                        characterControl.Attack = true;
                    }
                    else characterControl.Attack = false;
                    characterControl.MoveRight = false;
                    characterControl.MoveLeft = false;
                }
                else
                {
                    characterControl.Attack = false;
                    characterControl.MoveRight = player.position.x > transform.position.x;
                    characterControl.MoveLeft = player.position.x < transform.position.x;
                }
            }
            else
            {
                characterControl.MoveRight = false;
                characterControl.MoveLeft = false;
            }
        }
    }
}