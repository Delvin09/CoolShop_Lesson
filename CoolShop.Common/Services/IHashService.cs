using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShop.Common.Services
{
    public interface IHashService
    {
        (byte[] hash, byte[] salt) GetHash(string value, byte[]? key = null);

    }
}
