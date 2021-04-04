using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia
{
    public class CameraSetting : MonoBehaviour
    {

        private bool NO = true;
        // Use this for initialization
        void Start()
        {
            var vuforia = VuforiaARController.Instance;
            vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);//注册启动监听
            vuforia.RegisterOnPauseCallback(OnPaused);//注册暂停监听

        }
        //自动对焦
        void OnVuforiaStarted()
        {
            //CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
        //private void FixedUpdate()
        //{
        //    CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        //}
        void OnPaused(bool isPaused)
        {
            
        }
        //手动对焦
        public void OnFocusClick()
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }

        //切换镜头
        public void SwitchCameraDirection()
        {
            CameraDevice.Instance.Stop();
            CameraDevice.Instance.Deinit();

            if (CameraDevice.Instance.GetCameraDirection() == CameraDevice.CameraDirection.CAMERA_BACK)
                CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
            else
                CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_BACK);
            CameraDevice.Instance.Start();
        }
        //闪光灯
        public void FlashTourch()
        {

            CameraDevice.Instance.SetFlashTorchMode(NO);
            NO = !NO;
        }
    }
}

