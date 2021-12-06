using UnityEngine;

namespace BioPunk
{
    public class EnemyAI : MonoBehaviour
    {
        public CharacterControl characterControl;
        public Transform player;
        public float distanceToPursue;
        public float distanceToAttack;

        private void Update()
        {
            if (Vector3.Distance(player.position, transform.position) <= distanceToPursue)
            {
                if (Vector3.Distance(player.position, transform.position) <= distanceToAttack)
                {
                    characterControl.MoveRight = false;
                    characterControl.MoveLeft = false;
                    characterControl.Attack = true;
                }
                else
                {
                    characterControl.Attack = false;
                    if (player.position.x < transform.position.x)
                    {
                        characterControl.MoveRight = false;
                        characterControl.MoveLeft = true;
                    }
                    else
                    {
                        characterControl.MoveRight = true;
                        characterControl.MoveLeft = false;
                    }
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