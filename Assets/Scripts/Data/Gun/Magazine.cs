using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public List<Bullet> bullets;
    public int limit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Bullet extractRound()
    {
        Bullet extracted = null;
        if (!empty())
        {
            extracted = bullets[0];
            bullets.RemoveAt(0);
        }
        return extracted;
    }

    public void addRound(Bullet round)
    {
        if (!full())
        {
            bullets.Insert(0, round);
        }
    }

    public void addRounds(List<Bullet> toAdd)
    {
        while (!full() && toAdd.Count > 0)
        {
            addRound(toAdd[0]);
            toAdd.RemoveAt(0);
        }
    }

    public bool empty()
    {
        return bullets.Count == 0;
    }

    public bool full()
    {
        return bullets.Count == limit;
    }
}
