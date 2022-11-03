using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARRaycastManager))]

public class TryPlaneTracking : MonoBehaviour
{
  public Text debugText;
  private ARTrackedImageManager trackedImageManager;
  private ARPlaneManager planeManager;
  private ARRaycastManager raycastManager;

  [SerializeField]  //we don't want to make this public but we want it visible in the inspector
  private GameObject[] placeablePrefabs; //a list that holds all the prefabs(characters) that can be spawned

  private GameObject spawnedObject;  //object that will spawn upon tapping the phone's screen.
  private List<GameObject> placedPrefabList = new List<GameObject>();  //a list that will hold every spawnedObject

  [SerializeField]
  private int maxPrefabSpawnCount = 3; //for now we only need to spawn only one character each time.
  private int placedPrefabCount;  //keeping count of how many objects have been placed.
  private GameObject prefabToBePlaced; //this is the prefab (character) to be placed
  private Dictionary<string, GameObject> prefabNamesPrefabs = new Dictionary<string, GameObject>(); //Dictionary that will correlate prefab names and prefabs themselves.

  static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

//-------------------script lifecycle starts here--------------------------------

  private void Awake()
  {
    trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    planeManager = GetComponent<ARPlaneManager>();
    planeManager.enabled = false; //We do not want to track planes until we read the QR code which will provide us with the character prefab to be placed.
    raycastManager = GetComponent<ARRaycastManager>();

    foreach(GameObject prefab in placeablePrefabs)
    {
      prefabNamesPrefabs.Add(prefab.name, prefab);
    }

  }

  private void OnEnable()
  {
    trackedImageManager.trackedImagesChanged += ImageChanged;
  }

  private void Update()
  {
    if(!TryGetTouchPosition(out Vector2 touchPosition))
    {
      return;
    }
    if(raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon)) //if we hit a plane, we spawn the prefabToBePlaced.
    {
      var hitPose = s_Hits[0].pose;
      if(placedPrefabCount < maxPrefabSpawnCount)
      {
        debugText.text = "Prefab spawned. PlaneManager disabled.";
        SpawnPrefab(hitPose);
        planeManager.enabled = false; //we then disable the planeManager because its work here is done.
        ToggleAllPlanes(false);  //we also deactivate every plane we have built so far.
      }
    }
  }

  private void OnDisable()
  {
    trackedImageManager.trackedImagesChanged -= ImageChanged;
  }

//-------------------script lifecycle ends here----------------------------------

  private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
  {
    foreach(ARTrackedImage trackedImage in eventArgs.added)
    {
      planeManager.enabled = true; //we enable the plane manager to spawn prefab on plane
      //ToggleAllPlanes(true);  we also reactivate the planes we deactivated earlier
      ChangePrefabToBePlaced(trackedImage);
      debugText.text = "Image " + trackedImage.referenceImage.name + " was added. Scan a plane.";
    }
  }

  private void ChangePrefabToBePlaced(ARTrackedImage trackedImage)
  {
    string name = trackedImage.referenceImage.name;
    prefabToBePlaced = prefabNamesPrefabs[name];
  }


  bool TryGetTouchPosition(out Vector2 touchPosition)
  {
    //getting the position of where the finger was when it began touching the screen.
    if(Input.GetTouch(0).phase == TouchPhase.Began)
    {
      touchPosition = Input.GetTouch(0).position;
      return true;
    }
    touchPosition = default;
    return false;
  }


  private void SpawnPrefab(Pose hitPose)
  {
    spawnedObject = Instantiate(prefabToBePlaced, hitPose.position, hitPose.rotation);
    placedPrefabList.Add(spawnedObject);
    placedPrefabCount++;
  }


  private void ToggleAllPlanes(bool activation)
  {
    foreach(var plane in planeManager.trackables)
    {
      plane.gameObject.SetActive(activation);
    }
  }


}
