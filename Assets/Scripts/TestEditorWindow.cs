using System.Collections;
using UnityEditor; //This allows us to access elements of the editor code
using UnityEngine;


//Create a script that derives from EditorWindow
public class TestEditorWindow : EditorWindow
{
    //This is the menu, sub menu and window names
    [MenuItem("Rubber Duck/Tool Windows/Test Window")]
    //This public static function is what creates the window
    public static void ShowWindow()
    {
        //Get Window comes from EditorWindow
        //EditorWindow.GetWindow(typeof(TestEditorWindow));
        GetWindow(typeof(TestEditorWindow));
    }
    #region Variables for Editor Window
    string _objectBaseName = ""; //This is the variable that the user will input to name the object
    string _objectTag = ""; //Variable user will input the tag
    GameObject _objectToSpawn; //The actual game object that the player will spawn
    float _objectScale = 1; //Variable that controls the objects scale 
    Vector3 _objectTransform; //Variable that needs to be implemented to select the transform
    Vector4 _objectRotation; //Variable that needs to be implemented to control the rotation of the object.


    //need to set up the scale

    #endregion



    private void OnGUI()
    {
        //This is the display of the actual WINDOW!
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel); // Creates a Title name/Header , sets the style to BOLD


        _objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", _objectToSpawn, typeof(GameObject), false) as GameObject;
        //Setting the gameObject to false allows us to reference objects in the assets folder instead of scene objects 
        // This will prevent us from causing issues during runtime if the object is deleted from the scene

        //if (GUILayout.Button("Select Cube")) //Creates a button called spawn object that we can press
        //{

        //}

        //if (GUILayout.Button("Select Circle 2D")) //Creates a button called spawn object that we can press
        //{
        //    _objectToSpawn = Resources.Load
        //}


        if (_objectToSpawn != null)
        {
            // _objectTag = EditorGUILayout.TagField("Object Tag", _objectToSpawn.tag); // add a text field to fill out to tag th eobject
            _objectTag = EditorGUILayout.TagField("Object Tag", _objectToSpawn.tag != _objectTag ? _objectTag : _objectToSpawn.tag);
            _objectBaseName = EditorGUILayout.TextField("Object Name", _objectBaseName); // add a text field to fill out to set the Name

            _objectScale = EditorGUILayout.Slider("Object Scale", _objectScale, 0.25f, 10f); //Creates a sider, 0.25f MIN and 10f is the MAX

            if (GUILayout.Button("Spawn Object")) //Creates a button called spawn object that we can press
            {
                SpawnObject();
                //run spawn code
            }

        }


    }

    private void SpawnObject()
    {


        if (_objectBaseName == string.Empty) //If there is no name, send an error and return and exit the spawn object function
        {
            Debug.LogError("Error: Please enter a name for this object."); //creates the error
            return; //exits the function
        }
        GameObject _newObject = Instantiate(_objectToSpawn); //Spawns the object

        _newObject.transform.localScale = Vector3.one * _objectScale; //Sets the spawned objects transform to (X=0, Y=0, Z=0)
        _newObject.name = _objectBaseName; //Sets the spawned Objects name to the GUI Input field "Object Name"
        _newObject.tag = _objectTag; //Sets the spawned Objects name to the GUI Input field "Object Tag"
        // Instantiate(_objectToSpawn, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

    }

}
