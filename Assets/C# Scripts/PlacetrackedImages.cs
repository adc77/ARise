using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlacetrackedImages : MonoBehaviour
{
    //reference to AR tracked image manager component
    private ARTrackedImageManager _trackedImagesManager;

    //List of prefabs to instantiate - these should be named the same
    //as their corresponding 2D images in the reference image library
    public GameObject[] ArPrefabs;

    //keep dictionary array of created prefabs
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        //Cache a reference to the Tracked Image Manager component
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        //Attach event handler when tracked images change
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;

    }

    void OnDisable()
    {
        //Remove event handler
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    //Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //loop through all new tracked images that have been detected
        foreach (var trackedImage in eventArgs.added)
        {
            //Get the name of the reference image
            var imageName = trackedImage.referenceImage.name;
            //Now loop over the array of prefabs
            foreach (var curPrefab in ArPrefabs)
            {
                //check whether this prefab matches the tracked image name, and that
                //the prefab hasn't already been created
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                        && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    //Instantiate the prefab, parenting it to ARTrackedImage
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    //Add the creted prefab to our array
                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }

        //For all prefabs that have been created so far, set them active or not depending
        //on whether their correspondng image is currently being tracked
        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[(trackedImage.referenceImage.name)]
                .SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        //if the AR subsystem has given up looking for a tracked image
        foreach (var trackedImage in eventArgs.removed)
        {
            //Destroy its prefab
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            //Also remove the instance from our array
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
            //or, simply set the prefab instance to inactive
            //_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(false);
        }
    }
}