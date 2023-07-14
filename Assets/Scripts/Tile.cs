using UnityEngine;

public class Tile : MonoBehaviour
{
    PrefabInstancePool<Tile> pool;

    public Tile Spawn(Vector3 position)
    {
        if (pool == null)
            pool = new();
        Tile instance = pool.GetInstance(this);
        instance.pool = pool;
        instance.transform.localPosition = position;
        return instance;
    }

    public void Despawn() => pool.Recycle(this);
}
