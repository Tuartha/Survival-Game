using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 200f;
    [SerializeField]
    private Rigidbody2D _rb2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb2D.MoveRotation(_rb2D.rotation + _rotationSpeed * Time.fixedDeltaTime);
    }
}
