using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 访问修饰符
{
    /// <summary>
    /// 一共有五个修饰符
    ///1， public 
    /// 2，private
    /// 3，protected
    /// 4，internal:只能在当前程序集中访问
    /// 5，protected internal：protected+internal
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string containerId = "0b684d5d18fa4ca682610c240fe1450e";
            string accessKeyId;
            string accessKeySecrets;

            //accessKeyId的生成过程
            //进行sha256散列
            string sha256Digest = SHA256Encrypt(containerId);
            //获取字符串的CRC32校验值
            var cRC32Str = GetCRC32Str(sha256Digest);
            byte[] b = System.Text.Encoding.Default.GetBytes(cRC32Str.ToString());
            //转换为base64编码
            var covertBase64 = Convert.ToBase64String(b);
            //进行MD5加密处理
            accessKeyId = getMD5(covertBase64).ToUpper();

            //accessKeySecrets的生成
            accessKeySecrets = getMD5(Guid.NewGuid().ToString("N")).ToUpper();
            Console.WriteLine("accessKeyId:" + accessKeyId);
            Console.WriteLine("accessKeySecrets:" + accessKeySecrets);
            Console.ReadKey();
        }

        #region HmacMD5加密
        /// <summary>
        /// HmacMD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string getHmacMD5(string str)
        {
            HMACMD5 provider = new HMACMD5();
            byte[] hashedPassword = provider.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder displayString = new StringBuilder();
            for (int i = 0; i < hashedPassword.Length; i++)
            {
                displayString.Append(hashedPassword[i].ToString("X2"));
            }
            return displayString.ToString();
        }
        #endregion

        #region MD5加密
        private static string getMD5(string str)
        {
            //创建 MD5对象
            MD5 md5 = MD5.Create();//new MD5();
            //开始加密
            //需要将字符串转换成字节数组
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(str);
            //md5.ComputeHash(buffer);

            //返回一个加密好的字节数组
            byte[] MD5Buffer = md5.ComputeHash(buffer);
            //将字节数组 转换成字符串
            string strNew = "";
            for (int i = 0; i < MD5Buffer.Length; i++)
            {
                strNew += MD5Buffer[i].ToString("x2");
            }
            return strNew;
        }
        #endregion

        #region SHA256加密
        public static string SHA256Encrypt(string strIN)
        {
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();

            tmpByte = sha256.ComputeHash(GetKeyByteArray(strIN));
            sha256.Clear();

            return GetStringValue(tmpByte);

        }
        #endregion

        private static string GetStringValue(byte[] Byte)
        {
            string tmpString = "";
            ASCIIEncoding Asc = new ASCIIEncoding();
            tmpString = Asc.GetString(Byte);
            return tmpString;
        }

        private static byte[] GetKeyByteArray(string strKey)
        {
            ASCIIEncoding Asc = new ASCIIEncoding();
            int tmpStrLen = strKey.Length;
            byte[] tmpByte = new byte[tmpStrLen - 1];
            tmpByte = Asc.GetBytes(strKey);
            return tmpByte;
        }

        static protected ulong[] Crc32Table;
        //生成CRC32码表
        static public void GetCRC32Table()
        {
            ulong Crc;
            Crc32Table = new ulong[256];
            int i, j;
            for (i = 0; i < 256; i++)
            {
                Crc = (ulong)i;
                for (j = 8; j > 0; j--)
                {
                    if ((Crc & 1) == 1)
                        Crc = (Crc >> 1) ^ 0xEDB88320;
                    else
                        Crc >>= 1;
                }
                Crc32Table[i] = Crc;
            }
        }
        //获取字符串的CRC32校验值
        static public ulong GetCRC32Str(string sInputString)
        {
            //生成码表
            GetCRC32Table();
            byte[] buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(sInputString); ulong value = 0xffffffff;
            int len = buffer.Length;
            for (int i = 0; i < len; i++)
            {
                value = (value >> 8) ^ Crc32Table[(value & 0xFF) ^ buffer[i]];
            }
            return value ^ 0xffffffff;
        }
    }
}


