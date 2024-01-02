using System.Text;

namespace Crypto
{
    /// <summary>
    /// classe de criptografia para "brincar"
    /// baseado na versão php https://github.com/stribus/MyCripty/blob/master/class.cripto.php   
    /// </summary> 
    public class MyCrypto
    {
        private int key;
        private string salt;

        /// <summary>
        /// inicializa com os valores
        /// </summary>
        /// <param name="key">um numero primo usado para os calculos    </param>
        /// <param name="salt">salt </param>
        public MyCrypto(int key, string salt)
        {
            this.key = key;
            this.salt = salt;
        }

        public string Encrypt(string text)
        {
            text = text + salt;
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            if(base64.Length > int.MaxValue/this.key)
            {
                throw new Exception("Texto muito grande");
            }
            string result = "";
            int leng = base64.Length+1;
            for (int i = 1; i < leng; i++)
            {
                int ni = i * this.key;
                if (ni >= leng)
                {
                    ni = ni % leng;
                }
                if (ni == 0)
                {
                    ni = i;
                }
                result += base64[ni -1];
            }
            return result;
        }

        public string Decrypt(string text)
        {
            string result = "";
            int leng = text.Length+1;
            var n = this.key;

            for(int i = 1; i < leng; i++)
            {
                int ni = i * n;
                if (ni % leng == 1)
                {
                    n = i;
                    break;
                }
            }

            for (int i = 1; i < leng; i++)
            {
                int ni = i * n;
                if (ni >= leng)
                {
                    ni = ni % leng;
                }
                if (ni == 0)
                {
                    ni = i;
                }
                result += text[ni - 1];
            }

            byte[] base64 = Convert.FromBase64String(result);
            result = Encoding.UTF8.GetString(base64);
            result = result.Substring(0, result.Length - salt.Length);
            return result;
        }
    }
}