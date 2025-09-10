using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

/// <summary>
/// 视频播放控制类
/// </summary>
public class VideoController : MonoBehaviour
{
    // 播放状态
    bool isPlaying = false;
    // 视频播放对象
    public VideoPlayer videoPlayer;
    // 视频片段数组
    public VideoClip[] videoClips;
    // 当前播放的视频片段索引
    int currentClipIndex = 0;
    // 播放按钮文本切换：播放/暂停
    public GameObject playButton;

    // 设置当前播放的视频片段
    public void SetCurrentClip(int index)
    {
        currentClipIndex = index;
        videoPlayer.clip = videoClips[currentClipIndex];
    }

    // 播放/暂停视频
    public void PlayOrPause()
    {
        if (!isPlaying)
        {
            Play();
        }
        else
        {
            Pause();
        }
    }

    // 播放视频
    public void Play()
    {
        videoPlayer.Play();
        isPlaying = true;
        playButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Pause";
    }

    // 暂停视频
    public void Pause()
    {        
        videoPlayer.Pause();
        isPlaying = false;
        playButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Play";
    }

    // 停止视频
    public void Stop()
    {
        videoPlayer.Stop();
        isPlaying = false;
    }

    // 上一曲
    public void Previous()
    {
        currentClipIndex--;
        if (currentClipIndex < 0)
        {
            currentClipIndex = videoClips.Length - 1;
        }
        SetCurrentClip(currentClipIndex);
        Play();
    }

    // 下一曲
    public void Next()
    {
        currentClipIndex++;
        if (currentClipIndex >= videoClips.Length)
        {
            currentClipIndex = 0;
        }
        SetCurrentClip(currentClipIndex);
        Play();
    }
}
