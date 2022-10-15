using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private int maxDepth = 3;

    private Queue<GameObject> frontier = new Queue<GameObject>();
    private Queue<GameObject> newBranches = new Queue<GameObject>();
    private int currentDepth = 0;

    private void Start()
    {
        GameObject root = Instantiate(branchPrefab, transform);
        root.name = "Branch [root]";
        frontier.Enqueue(root);

        GenerateTree();
    }
    
    private void GenerateTree()
    {
        if (currentDepth >= maxDepth)
        {
            return;
        }
        currentDepth++;
        
      
        while (frontier.Count > 0)
        {
            var prevRoot = frontier.Dequeue();

            
            var leftBranch = CreateBranch(prevRoot, Random.Range(10f, 40f));
            var rightBranch = CreateBranch(prevRoot, -Random.Range(10f, 40f));

            // 1.2 store references of the new elements
            newBranches.Enqueue(leftBranch);
            newBranches.Enqueue(rightBranch);
        }

       
        int branches = newBranches.Count;
        for (int i = 0; i < branches; i++)
        {
            frontier.Enqueue(newBranches.Dequeue());
        }

        
        GenerateTree();
    }

    private GameObject CreateBranch(GameObject prevBranch, float offsetAngle)
    {
        GameObject branch = Instantiate(branchPrefab, transform);
        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up;
        branch.transform.rotation = prevBranch.transform.rotation * Quaternion.Euler(0f, 0f, offsetAngle);
        return branch;
    }
}