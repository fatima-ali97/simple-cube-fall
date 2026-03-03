using UnityEngine;

public class BGScroll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float scroll_speed = 0.3f;
    private MeshRenderer mesh_Renderer;


    private void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scroll();
        
    }
    void scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_speed;


        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
}
