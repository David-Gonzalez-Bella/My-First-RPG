using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Rocks : MonoBehaviour
{
    public static Rocks sharedInstance { get; private set; }
    public List<Transform> rocks;
    private Vector3[] positions;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    private void Start()
    {
        positions = new Vector3[2] { new Vector3(2.5f, -5.5f, 4.0f), new Vector3(-0.65f, -1.0f, 4.0f) };
    }

    public void ClearPath()
    {
        int p = 0;
        foreach(Transform rock in rocks)
        {
            if(rock.tag.CompareTo("Rock") != 0)
            {
                Destroy(rock.gameObject);
            }
            else
            {
                rock.localPosition = positions[p];
                p++;
            }
        }
    }

    [ContextMenu("Autofill Rocks")]
    public void AutofillRocks()
    {
        rocks = FindObjectsOfType<Transform>().Where(t => t.name.Contains("Rock")).ToList();
    }
}
