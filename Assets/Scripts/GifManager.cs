using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GifManager : MonoBehaviour
{
    Sprite[] sprite;
    float changeInterval = 1;
    char separator = Path.DirectorySeparatorChar;
    void Start()
    {
        List<Sprite> sprites = new();
        string[] files = {"1", "2", "3", "4", "5"};
        foreach (string file in files)
        {
            print(file);
            print(Resources.Load<Sprite>(file));
            sprites.Add(Resources.Load<Sprite>(file));
        }
        sprite = sprites.ToArray();
    }
    private void Update()
    {
        if (sprite.Length == 0) // nothing if no textures
            return;
        // we want this texture index now
        int index = (int)(Time.time / changeInterval);
        // take a modulo with size so that animation repeats
        index %= sprite.Length;
        gameObject.GetComponent<Image>().sprite = sprite[index];
        //print(sprite[index]);
    }

}