using UnityEngine;

namespace BioPunk
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl _characterControl;

        private void Awake()
        {
            _characterControl = this.gameObject.GetComponent<CharacterControl>();
        }

        private void Update()
        {
            _characterControl.MoveRight = VirtualInputManager.Instance.MoveRight;
            _characterControl.MoveLeft = VirtualInputManager.Instance.MoveLeft;
            _characterControl.Jump = VirtualInputManager.Instance.Jump;
            _characterControl.Attack = VirtualInputManager.Instance.Attack;
            _characterControl.weaponMelee = VirtualInputManager.Instance.weaponMelee;
            _characterControl.weaponFire = VirtualInputManager.Instance.weaponFire;
            _characterControl.weaponBasic = VirtualInputManager.Instance.weaponBasic;
            _characterControl.weaponEMP = VirtualInputManager.Instance.weaponEMP;
        }
    }
}
