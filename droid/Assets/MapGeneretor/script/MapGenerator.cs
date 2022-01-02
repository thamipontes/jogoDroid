
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Texture2D _texture2D;
    public ObjectInfo[] objectInfo;
    public Vector3 offset = Vector3.zero;

    private Vector2 pos;

    private void Start()
    {
        this.ReadTexture();
    }

    private void ReadTexture()
    {
        for (int x = 0; x < this._texture2D.width; x++)
        {
            for (int y = 0; y < this._texture2D.height; y++)
            {
                this.pos = new Vector2(x, y);
                this.GetColor(x, y);
            }
        }
    }

    private void GetColor(int x, int y)
    {
        Color c = this._texture2D.GetPixel(x, y);
        if (c.a < 1)
        {
            return;
        }
        
        this.CreateObject(c);
    }

    private void CreateObject(Color c)
    {
        foreach (ObjectInfo info in objectInfo)
        {
            if (info.color == c)
            {
                Instantiate(info.prefab, new Vector3(this.pos.x, 0, this.pos.y) + offset, Quaternion.identity,
                    this.transform);
                
            }
        }
        {
            
        }
    }
}
