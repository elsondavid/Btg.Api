﻿//using System.Security.Cryptography;
//using Microsoft.AspNetCore.Cryptography.KeyDerivation;

//namespace Btg.Core.Extensions;

//public static class HashPasswordExtensions
//{
//    public static string GetPasswordHash(this string password)
//    {
//        var prf = KeyDerivationPrf.HMACSHA256;
//        var rng = RandomNumberGenerator.Create();
//        const int iterCount = 10000;
//        const int saltSize = 128 / 8;
//        const int numBytesRequested = 256 / 8;

//        // Produce a version 3 (see comment above) text hash.
//        var salt = new byte[saltSize];
//        rng.GetBytes(salt);
//        var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

//        var outputBytes = new byte[13 + salt.Length + subkey.Length];
//        outputBytes[0] = 0x01; // format marker
//        WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
//        WriteNetworkByteOrder(outputBytes, 5, iterCount);
//        WriteNetworkByteOrder(outputBytes, 9, saltSize);
//        Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
//        Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
//        return Convert.ToBase64String(outputBytes);
//    }

//    public static bool VerifyHashedPassword(this string hashedPassword, string plainTextPassword)
//    {
//        var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

//        if (decodedHashedPassword[0] != 0x01)
//            return false;

//        var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);
//        var iterationCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);
//        var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

//        if (saltLength < 128 / 8)
//        {
//            return false;
//        }
//        var salt = new byte[saltLength];
//        Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

//        var subKeyLength = decodedHashedPassword.Length - 13 - salt.Length;
//        if (subKeyLength < 128 / 8)
//        {
//            return false;
//        }
//        var expectedSubKey = new byte[subKeyLength];
//        Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubKey, 0, expectedSubKey.Length);

//        var actualSubKey = KeyDerivation.Pbkdf2(plainTextPassword, salt, prf, iterationCount, subKeyLength);
//        return actualSubKey.SequenceEqual(expectedSubKey);
//    }

//    private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
//    {
//        buffer[offset + 0] = (byte)(value >> 24);
//        buffer[offset + 1] = (byte)(value >> 16);
//        buffer[offset + 2] = (byte)(value >> 8);
//        buffer[offset + 3] = (byte)(value >> 0);
//    }

//    private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
//    {
//        return ((uint)(buffer[offset + 0]) << 24)
//            | ((uint)(buffer[offset + 1]) << 16)
//            | ((uint)(buffer[offset + 2]) << 8)
//            | ((uint)(buffer[offset + 3]));
//    }
//}