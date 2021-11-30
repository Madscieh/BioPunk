using UnityEngine;

namespace BioPunk
{
    public class EnemyAI : MonoBehaviour
    {
        public CharacterControl _characterControl;
        //public GameObject player;
        public float distanceToPursue;
        public float distanceToAttack;
        public Transform player;

        private void Awake()
        {
            //_characterControl = this.gameObject.GetComponent<CharacterControl>();
            //playerPosition = player.GetComponent<Transform>().position;
        }

        private void Update()
        {
            if (Vector3.Distance(player.position, transform.position) <= distanceToPursue)
            {
                if (Vector3.Distance(player.position, transform.position) <= distanceToAttack)
                {
                    _characterControl.MoveRight = false;
                    _characterControl.MoveLeft = false;
                    _characterControl.Attack = true;
                }
                else
                {
                    _characterControl.Attack = false;
                    if (player.position.x < transform.position.x)
                    {
                        _characterControl.MoveRight = false;
                        _characterControl.MoveLeft = true;
                    }
                    else
                    {
                        _characterControl.MoveRight = true;
                        _characterControl.MoveLeft = false;
                    }
                }
            }
            else
            {
                _characterControl.MoveRight = false;
                _characterControl.MoveLeft = false;
            }
        }
    }
}