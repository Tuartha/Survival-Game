using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private float _speed;
    private Rigidbody2D _rgbd;
    private Transform _playerTransform;

    [SerializeField]
    private bool Stopped = false;

    [SerializeField]
    private GameObject _crabDead;

    public event Action OnDie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        Player player = FindAnyObjectByType<Player>();
        if (player != null) 
        {
            _playerTransform = player.transform;
        } else {
            Stopped = true;
        }
    }

    public void Setup(float speed, Transform player) {
        _speed = speed;
        _playerTransform = player;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() 
    {
        if (Stopped || _playerTransform == null) 
        {
            _rgbd.linearVelocity = Vector2.zero;
            return;
        }
        Vector3 directionToPlayer = (_playerTransform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, 0.8f);

        if (hit.collider != null && hit.collider.gameObject != gameObject && hit.collider.CompareTag("Enemy")) 
        {
            directionToPlayer += new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), 0f);
        }
        _rgbd.linearVelocity = directionToPlayer * _speed;
    }

    private void TakeDamage() 
    {
        Instantiate(_crabDead, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (OnDie != null) 
        {
            OnDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon")) 
        {
            TakeDamage();
        }
    }
}
