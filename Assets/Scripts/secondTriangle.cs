using UnityEngine;


public class secondTriangle : MonoBehaviour
{


    Mesh _mesh;
    MeshRenderer _meshRenderer;
    Vector3[] _vertices;
    int[] _triangles;

    public Material _material;

    // Use this for initialization
    void Start()
    {

        gameObject.AddComponent<MeshFilter>();
        _meshRenderer = gameObject.AddComponent<MeshRenderer>();

        _meshRenderer.material = _material;
        _material.color = Color.black;

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

        _vertices = new[] {
            new Vector3(-2.25f,-2.01f,0),
            new Vector3(0,1.915065f,0),
            new Vector3(2.25f,-2.01f,0),

        };


        _mesh.vertices = _vertices;

        _triangles = new[] { 0, 1, 2 };

        _mesh.triangles = _triangles;



    }

    // Update is called once per frame
    void Update()
    {

    }
}