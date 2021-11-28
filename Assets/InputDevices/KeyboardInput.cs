using UnityEngine;

namespace BioPunk
{
    public class KeyboardInput : MonoBehaviour
    {
        private void Update()
        {
            VirtualInputManager.Instance.MoveRight = Input.GetKey(KeyCode.D);
            VirtualInputManager.Instance.MoveLeft = Input.GetKey(KeyCode.A);
            VirtualInputManager.Instance.Jump = Input.GetKey(KeyCode.Space);
            VirtualInputManager.Instance.Attack = Input.GetMouseButtonDown(0);
            VirtualInputManager.Instance.weaponMelee = Input.GetKey(KeyCode.Alpha1);
            VirtualInputManager.Instance.weaponFire = Input.GetKey(KeyCode.Alpha2);
            VirtualInputManager.Instance.weaponBasic = Input.GetKey(KeyCode.Alpha3);
            VirtualInputManager.Instance.weaponEMP = Input.GetKey(KeyCode.Alpha4);
        }
    }
}
