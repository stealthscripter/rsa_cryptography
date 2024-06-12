using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1 {
    public class RsaEnc {

        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privatekey;
        private RSAParameters _publickey;

        public RsaEnc() {
            _privatekey = csp.ExportParameters(true);
            _publickey = csp.ExportParameters(false);
        }

        public string PublicKeyString() {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _publickey);
            return sw.ToString();
        }

        public string Encrypt(string plainText) {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_publickey);
            var data = Encoding.Unicode.GetBytes(plainText);
            var cypher = csp.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }

        public string Decrypt(string cypherText) {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privatekey);
            var plainText = csp.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }

    class Program {
        static void Main(string[] args) {
            RsaEnc rs = new();
            string cypher = String.Empty;

            Console.WriteLine($"PublicKey: \n{rs.PublicKeyString()}\n");

            Console.WriteLine("Enter Your Text to Encrypt: ");
            var text = Console.ReadLine();

            if (!string.IsNullOrEmpty(text)) {
                cypher = rs.Encrypt(text);
                Console.WriteLine($"Cypher Text: {cypher}\n");
            }

            Console.WriteLine("Press enter to decrypt");
            Console.ReadLine();
            var plainText = rs.Decrypt(cypher);
            Console.WriteLine("Decrypted Text: ");
            Console.WriteLine(plainText);
            Console.ReadLine();
        }
    }
}
