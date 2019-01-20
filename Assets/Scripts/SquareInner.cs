using UnityEngine;

public class SquareInner : MonoBehaviour
{


    Mesh _mesh;
    MeshRenderer _meshRenderer;
    Vector3[] _vertices;
    int[] _squares;

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
            new Vector3(-1.75f,-1.75f,0),
            new Vector3(-1.75f,1.75f,0),
            new Vector3(1.75f,1.75f,0),
            new Vector3(1.75f,-1.75f,0),

        };


        _mesh.vertices = _vertices;

        _squares = new[] { 0, 1, 2, 0, 2, 3 };

        _mesh.triangles = _squares;



    }

    // Update is called once per frame
    void Update()
    {

    }
}