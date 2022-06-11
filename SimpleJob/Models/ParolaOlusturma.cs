﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SimpleJob.Models
{
    public static class ParolaOlusturma
    {
        private readonly static Random _rand = new Random();

        public static string Olustur(int length = 24)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "1234567890";


            // Get cryptographically random sequence of bytes
            var bytes = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(bytes);

            // Build up a string using random bytes and character classes
            var res = new StringBuilder();
            foreach (byte b in bytes)
            {
                // Randomly select a character class for each byte
                switch (_rand.Next(4))
                {
                    // In each case use mod to project byte b to the correct range
                    case 0:
                        res.Append(lower[b % lower.Count()]);
                        break;
                    case 1:
                        res.Append(upper[b % upper.Count()]);
                        break;
                    case 2:
                        res.Append(number[b % number.Count()]);
                        break;
            
                }
            }
            return res.ToString();
        }
    }
}