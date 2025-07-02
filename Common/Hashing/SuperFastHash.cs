using System;

namespace Org.Edgerunner.ANTLR4.Tools.Common.Hashing
{
   public static class SuperFastHash
   {
      public static uint Hash(string input)
      {
         byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
         return Hash(data, data.Length);
      }

      private static uint Hash(byte[] data, int length)
      {
         uint hash = 0;
         int index = 0;
         while (length >= 4)
         {
            hash += BitConverter.ToUInt32(data, index);
            hash = (hash << 13) | (hash >> 19);
            hash += BitConverter.ToUInt32(data, index + 4);
            length -= 4;
            index += 4;
         }

         // Handle remaining bytes
         switch (length)
         {
            case 3:
               hash += (uint)(data[index + 2] << 16);
               goto case 2;
            case 2:
               hash += (uint)(data[index + 1] << 8);
               goto case 1;
            case 1:
               hash += data[index];
               break;
         }

         hash ^= hash >> 15;
         hash *= 0x85EBCA6B;
         hash ^= hash >> 13;
         hash *= 0xC2B2AE35;
         hash ^= hash >> 16;
         return hash;
      }
   }
}