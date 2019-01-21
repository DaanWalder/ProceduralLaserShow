using UnityEngine;


public class Triangle : MonoBehaviour
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

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

        _vertices = new[] {
            new Vector3(-2.5f,-2.165065f,0),
            new Vector3(0,2.165065f,0),
            new Vector3(2.5f,-2.165065f,0),

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