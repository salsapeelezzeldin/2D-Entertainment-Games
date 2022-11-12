using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite Sign;
    public Sprite checkedSign;
    private SpriteRenderer Renderer;
    public bool Checked;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            Renderer.sprite = checkedSign;
            Checked = true;
        }
    }
}