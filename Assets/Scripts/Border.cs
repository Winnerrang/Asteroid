using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{

    private static Border m_instance;

    public static Border Instance => m_instance;

    private Collider2D m_Collider;

    public float maxX => m_Collider.bounds.max.x;
    public float minX => m_Collider.bounds.min.x;
    public float maxY => m_Collider.bounds.max.y;
    public float minY => m_Collider.bounds.min.y;

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
