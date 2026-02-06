using UnityEngine;

public class CloudsController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _clouds = new Transform[6]; 
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _xLimit = 12.81f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _clouds.Length; i++)
        {
            _clouds[i].position = _clouds[i].position + Vector3.right * Time.deltaTime * _speed; 

            float halfCloudWidth = _clouds[i].GetComponent<SpriteRenderer>().bounds.extents.x;
            if (_clouds[i].position.x - halfCloudWidth > _xLimit) {
                float StartX = 2 * _xLimit + halfCloudWidth;
                _clouds[i].position -= new Vector3(StartX, 0, 0);
            }

            // if (_clouds[i].position.x > _xLimit)
            // {
            //     _clouds[i].position -= new Vector3(2 * _xLimit, 0, 0);
            // }
        }
    }
}
