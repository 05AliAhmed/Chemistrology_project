using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ShootableElectronScript prefab;
    [SerializeField] private int initialSize = 1;

    private readonly Queue<ShootableElectronScript> free = new();

    public ShootableElectronScript Get()
    {
        ShootableElectronScript bullet = free.Count > 0
            ? free.Dequeue()
            : Instantiate(prefab);

        bullet.gameObject.SetActive(true);
        bullet.OnSpawn();
        return bullet;
    }

    public void Return(ShootableElectronScript bullet)
    {
        bullet.OnDespawn();
        bullet.gameObject.SetActive(false);
        free.Enqueue(bullet);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
