using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] Transform _centralObject;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(_centralObject.position);

        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;
        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;

        _centralObject.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }
}