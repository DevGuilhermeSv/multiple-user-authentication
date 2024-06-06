using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Options
{
    public class JWTSchemeOptions
    {
        public IEnumerable<string> ValidAudiences { get; set; }
        public SigningKey[] SigningKeys { get; set; }
        public string ValidIssuer { get; set; }
    }
    public class SigningKey
    {
        public string Id { get; set; }
        public string Issuer { get; set; }
        public string Value { get; set; }
        public int Length { get; set; }
    }
}
