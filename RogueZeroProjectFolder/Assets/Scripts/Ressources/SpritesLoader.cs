using System.Collections.Generic;
using UnityEngine;

public class SpritesLoader : MonoBehaviour
{

    public static List<Sprite> SpriteList = new List<Sprite>();
    public List<Sprite> ViewableSpriteList = new List<Sprite>();

    void Awake()
    {
        SpriteList = ViewableSpriteList;
    }

    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
