using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool _flipRight = true;

    private void Update()
    {
        if ((!_flipRight && Player._horizontal > 0) || (_flipRight && Player._horizontal < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
            _flipRight = !_flipRight;
        }
    }
}
