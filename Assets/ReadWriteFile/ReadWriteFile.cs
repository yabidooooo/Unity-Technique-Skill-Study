using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace ReadWriteFile
{
    public class ReadWriteFile : MonoBehaviour
    {
        public RawImage rawImg;    // 불러올 이미지

        void Start()
        {
            LoadGameData();
        }

        public void LoadGameData()
        {
            // 경로 지정
            string _path = Application.persistentDataPath + "/Jeju.PNG";

            if (!File.Exists(_path))
            {
                Debug.Log("파일이 없는데요");
                return;
            }

            // 이미지를 byte로 읽기
            byte[] byteTextures = File.ReadAllBytes(_path);

            // 파일 쓰기
            File.WriteAllBytes(_path, byteTextures);

            // 임시이미지로 변환
            var tempImage = File.ReadAllBytes(_path);

            // 텍스쳐 설정 후, 임시이미지로 변환
            Texture2D texture = new Texture2D(2048, 1024);
            texture.LoadImage(tempImage);

            // 유니티 이미지에 임시이미지 넣기
            rawImg.texture = texture;
        }
    }
}