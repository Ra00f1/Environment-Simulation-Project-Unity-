using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class RayCastSc : MonoBehaviour
{
    public int NumberOfRays;
    public int layerMask;
    private int degerees;

    private Vector3 Direction;

    public Color Color1;
    public Color Color2;

    private RaycastHitSorter RaycastHitSorter;

    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
        RaycastHitSorter = GameObject.FindObjectOfType<RaycastHitSorter>();
    }
    void FixedUpdate()
    {
    }
    public void Cast()
    {
        degerees = 360 / NumberOfRays;

        for (int i = 0; i < NumberOfRays; i++)
        {
            float sin = Mathf.Sin(Mathf.Deg2Rad * (degerees * i)) * 2;
            if (sin > 0)
                sin = -sin + 1;

            float cos = Mathf.Cos(Mathf.Deg2Rad * (degerees * i)) * 2;
            //if (cos < 0)
            //    cos = -cos;

            RaycastHit hit;
            Direction = new Vector3(0, sin, cos);

            if (Physics.Raycast(transform.position, Direction, out hit, Mathf.Infinity))
            {
                if(hit.transform.gameObject.tag == "Ground")
                {
                    Debug.DrawRay(transform.position, Direction * hit.distance, Color.yellow);

                    MeshRenderer rend = hit.transform.GetComponent<MeshRenderer>();
                    MeshCollider meshCollider = hit.collider as MeshCollider;

                    if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                        return;

                    MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
                    Texture2D texture2D = renderer.material.mainTexture as Texture2D;
                    Vector2 pCoord = hit.textureCoord;
                    pCoord.x *= texture2D.width;
                    pCoord.y *= texture2D.height;

                    Vector2 tiling = renderer.material.mainTextureScale;
                    Color color = texture2D.GetPixel(Mathf.FloorToInt(pCoord.x * tiling.x), Mathf.FloorToInt(pCoord.y * tiling.y));
                    if (color == Color1)
                    {
                        RaycastHitSorter.Sort(hit.transform.position);
                    }
                    if (color == Color2)
                    {
                        RaycastHitSorter.Sort(hit.transform.position);
                    }
                }
            }
            else
            { 
                Debug.DrawRay(transform.position, Direction * 2000, Color.white);
            }
        }
    }
}