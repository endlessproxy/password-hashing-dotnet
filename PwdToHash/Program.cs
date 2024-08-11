using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace PwdToHash;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Clear();

            Console.Write("Digite a sua senha aqui: ");
            var pwd = Console.ReadLine();

            var hashedPwd = BCrypt.Net.BCrypt.HashPassword(pwd);

            Console.WriteLine($"\nSenha Hasheada: {hashedPwd}\n");

            Console.Write("Digite a senha para verificar: ");
            var pwdToVerify = Console.ReadLine();
            var isMatch = BCrypt.Net.BCrypt.Verify(pwdToVerify, hashedPwd);

            if (isMatch)
            {
                Console.WriteLine("\nA senha está correta.\n");
            }

            if (!isMatch)
            {
                Console.WriteLine("\nA senha está incorreta.\n");                                                                
            }
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
            throw;
        }
    }
}
