using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Student1{ 
public class CharacterAnimation : MonoBehaviour
{
    public Animator[] student;
    // public Text animationNameText;
    private int animationIndex = 0;
    private float direction = .5f;
    public Camera mainCamera;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            animationIndex = 2;
            direction = .5f;
            FlipStudents();
            PlayAnimation();
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            animationIndex = 2;
            direction = -.5f;
            FlipStudents();
            PlayAnimation();
        }
        // }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Walk();
        }  else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
            animationIndex = 0;
            PlayAnimation();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            animationIndex = 3;
            PlayAnimation();
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && arrow.activeSelf) {
            SceneManager.LoadScene("Menu");
        }
    }

    public void PlayAnimation()
    {
        for (int i = 0; i < student.Length; i++)
        {
            int clipCount = student[i].runtimeAnimatorController.animationClips.Length;

            if (animationIndex >= 0 && animationIndex < clipCount)
            {
                string animationName = student[i].runtimeAnimatorController.animationClips[animationIndex].name;
                student[i].Play(animationName, 0, 0f);
            }
            else
            {
                Debug.LogError("Invalid animation index: " + animationIndex);
            }
        }
    }

    private void FlipStudents()
    {
        for (int i = 0; i < student.Length; i++)
        {
            FlipHorizontal(student[i].gameObject);
        }
    }

    public void FlipHorizontal(GameObject StudentFrames)
    {
        Vector3 scale = StudentFrames.transform.localScale;
        scale.x = direction; // Flip the x scale
        StudentFrames.transform.localScale = scale;
    }

    private void Walk()
    {
        for (int i = 0; i < student.Length; i++)
        {
            Move(student[i].gameObject);
        }
    }

    public void Move(GameObject studentFrames)
    {
        if (mainCamera != null)
        {
            float cameraPosX = mainCamera.transform.position.x;
            Vector3 newPosition = new Vector3(cameraPosX, studentFrames.transform.position.y, studentFrames.transform.position.z);
            studentFrames.transform.position = newPosition;
        }
        else
        {
            Debug.LogError("Main camera not found!");
        }
    }
    // void MoveCamera()
    // {
    //     // You can define the logic for moving the camera here
    //     // For example, move the camera based on the arrow keys
    //     float horizontalInput = Input.GetAxis("Horizontal");

    //     Vector3 moveDirection = new Vector3(direction, 0f, 0f).normalized;

    //     // Call the MoveCamera method in the CameraMovement script
    //     cameraMovement.MoveCamera(moveDirection);
    // }
}
}