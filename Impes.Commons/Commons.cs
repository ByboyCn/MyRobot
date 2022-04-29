using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Impes.Commons
{
    public static class Commons
    {
        /// <summary>
        /// aes加密
        /// </summary>
        /// <param name="byte"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] AESEncrypt(this byte[] byteArray, byte[] key)
        {
            using var aes = new System.Security.Cryptography.RijndaelManaged();
            aes.Key = key;
            aes.Mode = System.Security.Cryptography.CipherMode.ECB;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            var cTransform = aes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(byteArray, 0, byteArray.Length);
            return resultArray;
        }

        /// <summary>
        /// aes解密
        /// </summary>
        /// <param name="byte"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] AESDecrypt(this byte[] byteArray, byte[] key)
        {
            using var aes = new System.Security.Cryptography.RijndaelManaged();
            aes.Key = key;
            aes.Mode = System.Security.Cryptography.CipherMode.ECB;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            var cTransform = aes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(byteArray, 0, byteArray.Length);
            return resultArray;
        }

        /// <summary>
        /// protobuf序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ProtobufSerialize<T>(this T obj)
        {
            using var ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize(ms, obj);
            return ms.ToArray();
        }

        /// <summary>
        /// protobuf反序列化
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static T ProtobufDeserialize<T>(this byte[] byteArray)
        {
            using var ms = new MemoryStream(byteArray);
            return ProtoBuf.Serializer.Deserialize<T>(ms);
        }

        /// <summary>
        /// zilb压缩
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static byte[] ZlibCompress(this byte[] byteArray)
        {
            using var ms = new MemoryStream();
            using var zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
            zip.Write(byteArray, 0, byteArray.Length);
            zip.Close();
            ms.Position = 0;
            var result = new byte[ms.Length];
            ms.Read(result, 0, result.Length);
            return result;
        }

        /// <summary>
        /// zilb解压缩
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static byte[] ZlibDecompress(this byte[] byteArray)
        {
            using var ms = new MemoryStream(byteArray);
            using var zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress);
            var result = new byte[byteArray.Length];
            zip.Read(result, 0, result.Length);
            return result;
        }

    }
}
