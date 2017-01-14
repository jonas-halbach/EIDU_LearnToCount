using UnityEngine;

public class ObjectInfo {

    public Vector2 Position
    {
        get; set;
    }

    public float Width
    {
        get; set;
    }

    public float Height
    {
        get; set;
    }

    public override bool Equals(object obj)
    {
        bool isEqual = false;
        if (Object.ReferenceEquals(this, obj))
        {
            isEqual = true;
        }
        else
        {
            ObjectInfo instance = obj as ObjectInfo;
            if (instance != null)
            {
                isEqual = this.Position.Equals(instance.Position) && Mathf.Approximately(this.Width, instance.Width) && Mathf.Approximately(this.Height, instance.Height);
            }
        }
        return isEqual;
    }

    public override int GetHashCode()
    {
        return this.Position.GetHashCode() ^ this.Width.GetHashCode() ^ this.Height.GetHashCode();
    }

}
