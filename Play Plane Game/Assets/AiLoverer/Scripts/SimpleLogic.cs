using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLogic : MonoBehaviour
{
    public GameObject target;
    public float speed = 3.0f;
    [Tooltip("旋转速度")]
    public float rotationSpeed = 60.0f;

    Vector3 moveDirection;

    public Material[] materials;

    private void Awake() {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        GameObject cube = this.gameObject;
        string name = cube.name;
        Debug.Log("Cube name: " + name);

        Transform cubeTransform = cube.transform;
        Vector3 position = cubeTransform.position;
        Debug.Log("Cube position: " + position.ToString("F3"));

        Vector3 scale = cubeTransform.localScale;
        Debug.Log("Cube scale: " + scale.ToString("F3"));

        Vector3 rotation = cubeTransform.localRotation.eulerAngles;
        Debug.Log("Cube rotation: " + rotation.ToString("F3"));

        Vector3 localPosition = cubeTransform.localPosition;
        Debug.Log("Cube local position: " + localPosition.ToString("F3"));

        Vector3 worldPosition = cubeTransform.position;
        Debug.Log("Cube world position: " + worldPosition.ToString("F3"));

        // this.transform.localPosition = new Vector3(1, 2, 3);
        // this.transform.localScale = new Vector3(1, 2, 3);
        // this.transform.localRotation = Quaternion.Euler(0, 45, 0);

        // 设置cube的朝向某个物体移动
        // target = GameObject.Find("Sphere");
        Vector3 targetPosition = target.transform.position;

        // 设置cube的朝向某个物体移动
        moveDirection = targetPosition - this.transform.position;
        moveDirection.Normalize();
        this.transform.LookAt(targetPosition);

    }

    // Update is called once per frame
    void Update()
    {

        // 绕自身旋转
        // Vector3 rotation = this.transform.localRotation.eulerAngles;
        // rotation.y += rotationSpeed * Time.deltaTime;
        // this.transform.localEulerAngles = rotation;
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);


        Vector3 targetPosition = target.transform.position;
        Vector3 direction = targetPosition - this.transform.position;
        if(direction.magnitude > 0.3f){
            
            float distance = speed * Time.deltaTime;

            //Debug.Log("Update" + Time.deltaTime);
            // Vector3 position = this.transform.localPosition;
            // position.x += distance;
            // this.transform.localPosition = position;
            //this.transform.Translate(Vector3.forward * distance);
            this.transform.position += moveDirection * distance;
        }

        // 鼠标左键按下
        if(Input.GetMouseButtonDown(0)){
           // PlayAudio();
            ChangeMaterial();
        }
        
    }

    void PlayAudio(){
        AudioSource audioSource = this.GetComponent<AudioSource>();
        if(audioSource != null){
            
            if(audioSource.isPlaying){
                Debug.Log("Audio is playing, stop it");
                audioSource.Stop();
            }else{
                Debug.Log("Audio is not playing, play it");
                audioSource.Play();
            }
        }else{
            Debug.Log("AudioSource is null");
        }
    }

    void ChangeMaterial(){
        int index = Random.Range(0, materials.Length);
        this.GetComponent<Renderer>().material = materials[index];
    }
}
