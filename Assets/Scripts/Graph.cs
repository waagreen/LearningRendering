using Unity.Collections;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform PointPrefab;
    [SerializeField][Range(10, 200)] private int resolution = 10;

    void Start()
    {
        float step = 2f / resolution ;

        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;

        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(PointPrefab, transform);
            
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x;

            point.localScale = scale;
            point.position = position;
        }
    }

    void Update()
    {
        
    }
}
