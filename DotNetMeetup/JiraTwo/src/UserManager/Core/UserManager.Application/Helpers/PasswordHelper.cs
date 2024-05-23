using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace UserManager.Application.Helpers;

public static class PasswordHelper
{
    private const int Iterations = 2;
    private const int DegreeOfParallelism = 2;
    public static byte[] GenerateSalt(int size)
    {
        var salt = new byte[size];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        return salt;
    }

    public static string HashPassword(string password, byte[]? salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

        // Set the salt (should be unique per user), you can generate it using a cryptographic random number generator
        argon2.Salt = salt ?? GenerateSalt(15);
        // Set the amount of memory to use (in KB)
        argon2.MemorySize = 8192; // 8 MB
        // Set the number of iterations
        argon2.Iterations = Iterations;
        // Set the number of threads or parallelism
        argon2.DegreeOfParallelism = DegreeOfParallelism;

        // Generate the hash
        var hashBytes = argon2.GetBytes(16); // Generates a 16 byte hash
        return Convert.ToBase64String(hashBytes);
    }
}