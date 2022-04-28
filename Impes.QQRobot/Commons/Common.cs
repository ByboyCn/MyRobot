using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impes.QQRobot.Commons
{
    /// <summary>
    /// 工具类
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str">需要加密的byte数组</param>
        /// <returns>加密后的byte数组</returns>
        public static byte[] MD5(this byte[] str)
        {
            using System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(str);
            return result;
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str">需要加密的byte数组</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5ByString(this  byte[] str)
        {
            var result = MD5(str);
            var sb = new StringBuilder();
            foreach (byte b in result)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }




    }
}
