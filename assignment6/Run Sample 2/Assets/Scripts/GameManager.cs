using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;
    
    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Character == null) return;

        MoveCharacter();
    }

    // For smooth cam moving, it's good to use LateUpdate.
    void LateUpdate()
    {

        if (Character == null) return;

        MoveCam();
    }

    void MoveCam()
    {
        Vector3 Cam_Pos = Character.transform.position;
        Cam_Pos.z = CamObj.transform.position.z;

        CamObj.transform.position = Cam_Pos;

      //Z만 유지.
    }

    void MoveCharacter()
    {

        if (Character == null) return;
        // Character는 초당 CharacterSpeed의 속도로 우측으로 움직인다.
        // ---------- TODO ---------- 
        Character.transform.position += Vector3.right * CharacterSpeed * Time.deltaTime;
        // -------------------- 
     
    }

    public void GameOver()
    {
        // Character를 삭제하고, "Game Over!"라는 메시지를 3초간 띄우고, RestartButton을 활성화한다.
        // ---------- TODO ---------- 

        Destroy(Character.gameObject);
        MyUIManager.DisplayMessage("Game Over!", 3f);
        MyUIManager.RestartButton.SetActive(true);


        
        
        // -------------------- 
    }

    public void GetPoint(int point)
    {
        // point만큼 점수를 증가시키고 UI에 표시한다.
        // ---------- TODO ---------- 

        NowScore += point;
        MyUIManager.DisplayScore(NowScore);

        // -------------------- 
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
