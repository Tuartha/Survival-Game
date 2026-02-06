using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string _horizontal = "Horizontal",
                   _vertical = "Vertical";
    [SerializeField]
    private Rigidbody2D _rgbd;

    private Vector2 _input;
    [SerializeField]
    public float _speed = 3f;

    public UnityEvent OnPlayerDeath;

    private void FixedUpdate()
    {
        _rgbd.linearVelocity = _input * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        float movaHorizontal = Input.GetAxis(_horizontal); // left right
        float movaVertical = Input.GetAxis(_vertical); // up down
        _input = new Vector2(movaHorizontal, movaVertical);
        _input.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnPlayerDeath != null) 
        {
            OnPlayerDeath.Invoke();
        }
        Destroy(gameObject);
    }

}
