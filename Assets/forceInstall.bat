"C:\Program Files\Unity\Hub\Editor\2019.1.0f2\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools\adb.exe" uninstall com.oculus.UnitySample
"C:\Program Files\Unity\Hub\Editor\2019.1.0f2\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools\adb.exe" install -r C:\Users\hwilson12\Documents\ReEnergise_PreAlpha.apk
"C:\Program Files\Unity\Hub\Editor\2019.1.0f2\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools\adb.exe" shell am start -S -a android.intent.action.MAIN -n com.oculus.UnitySample/com.unity3d.player.UnityPlayerActivity
"C:\Program Files\Unity\Hub\Editor\2019.1.0f2\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools\adb.exe" shell input keyevent KEYCODE_WAKEUP
