using UnityEngine;

namespace BioPunk
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Attack;
        public bool weaponMelee;
        public bool weaponFire;
        public bool weaponBasic;
        public bool weaponEMP;
    }
}
