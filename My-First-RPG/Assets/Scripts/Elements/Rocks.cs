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
        positions = new Vector3[2] { new Vector3(15f, 23.0f, 4.0f), new Vector3(15.7f, 18.2f, 4.0f) };
    }

    public void ClearPath()
    {
        if (rocks.Count > 4) //If the path as not been cleared yet
        {
            foreach (Transform rock in rocks)
            {
                if (rock.tag.CompareTo("Rock") != 0)
                {
                    Destroy(rock.gameObject);
                }
                else
                {
                    if(rock.gameObject.name.Contains("RockB")) rock.transform.position = positions[0];
                    else rock.transform.position = positions[1];
                }
            }
        }
    }

    [ContextMenu("Autofill Rocks")]
    public void AutofillRocks()
    {
        rocks = FindObjectsOfType<Transform>().Where(t => t.name.Contains("Rock")).ToList();
    }
}
