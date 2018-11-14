using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreator : MonoBehaviour {

    public GameObject[] trees;
    public float minDistanceBetweenTrees; // min X distance
    public float maxDistanceBetweenTrees; // max X distance
    public float randomFactorPositionX;
    public bool isRightSide; // if false, the trees should be created 
                             // on the left side of the river

    private int numberOfTreesGeneratedEachTime = 1000;
    private float positionZforLastGeneratedTree = 0; // reference point to know 
                                                     // where the next tree 
                                                     // should be placed

	// Use this for initialization
	void Start () {
        generateBulkOfTrees();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // creates X many trees
    void generateBulkOfTrees() {
        // To mirror the positions on left and right side of the river
        int riverSidePicker; 
        if (isRightSide) {
            riverSidePicker = 1;
        } else {
            riverSidePicker = -1;
        }

        Debug.Log("riverside picker: " + riverSidePicker);


        for (int i = 0; i < numberOfTreesGeneratedEachTime; i++) {
            // we create a little bit random factor where the X position of 
            // the tree is, so the trees are not in straight line
            float randomDifferentPositionX = Random.Range(0, randomFactorPositionX) * riverSidePicker;

            float zPosition = positionZforLastGeneratedTree + Random.Range(minDistanceBetweenTrees, maxDistanceBetweenTrees);
            positionZforLastGeneratedTree = zPosition;

            // random select one of the tree
            GameObject tree = trees[Random.Range(0, trees.Length)];

            // Set position of the tree
            float edgePositionOfRiver = -33.0f * riverSidePicker;
            Vector3 spawnPosition = new Vector3(transform.position.x + edgePositionOfRiver + randomDifferentPositionX,
                                                0,
                                                zPosition);
            Quaternion spawnRotation = Quaternion.identity;

            // Instantiate the object on the map
            Instantiate(tree, spawnPosition, spawnRotation);
        }

    }
}
