using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GifManager : MonoBehaviour
{
    Sprite[] sprite;
    float changeInterval = 1;
    char separator = Path.DirectorySeparatorChar;
    void Start()
    {
        string name = UICreateStar.latestPlanet ?? "ASASSN-V J100211.71-192537.4"; // for test
        List<Sprite> sprites = new();
        foreach (int index in Enumerable.Range(1, 10))
        {
            Sprite sprite = Resources.Load<Sprite>($"{name} ({index})");
            if(sprite != null)
                sprites.Add(sprite);
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
        print(index);
    }

}