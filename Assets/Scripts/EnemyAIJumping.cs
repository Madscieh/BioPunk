using UnityEngine;

namespace BioPunk
{
    public class EnemyAIJumping : MonoBehaviour
    {
        public CharacterControl characterControl;
        public Transform player;
        public float distanceToPursue;
        public float distanceToAttack;

        private void Update()
        {
            if (Vector3.Distance(player.position, transform.position) <= distanceToPursue)
            {
                characterControl.Jump = (Vector3.Distance(player.position, transform.position) <= distanceToAttack);
                characterControl.MoveRight = player.position.x > transform.position.x;
                characterControl.MoveLeft = player.position.x < transform.position.x;
            }
            else
            {
                characterControl.MoveRight = false;
                characterControl.MoveLeft = false;
            }
        }
    }
}