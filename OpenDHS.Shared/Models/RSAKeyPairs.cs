using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenDHS.Shared.Models
{
    public class RSAKeyPairs
    {
        public RSAParameters  PublicKey { get; set; }
        public RSAParameters PrivateKey { get; set; }

     
    }

    public static class RSAKeyPairsExtensions {
        public static string GetStringPublicKey(this RSAKeyPairs rsaKeyPairs)
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(sw, rsaKeyPairs.PublicKey);
            return sw.ToString();
        }
        public static string GetStringPrivateKey(this RSAKeyPairs rsaKeyPairs)
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(sw, rsaKeyPairs.PrivateKey);
            return sw.ToString();
        }
    }
}
