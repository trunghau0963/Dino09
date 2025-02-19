using UnityEngine;

public class Parralax : MonoBehaviour
{
    private Material _material;
    [SerializeField] 
    private float parralexFactor = 0.01f;
    private float offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxScroll();
    }

    private void ParallaxScroll()
    {
        float speed = GameManager.instance.GetGameSpeed() * parralexFactor;
        offset -= speed * Time.deltaTime;
        _material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
