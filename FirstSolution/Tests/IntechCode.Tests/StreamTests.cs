using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntechCode.Tests
{
    [TestFixture]
    public class StreamTests
    {
        const string demoPath = @"D:\VS2017_Projets\2017-1-IL-A4\FirstSolution\Tests\IntechCode.Tests\StreamTests.cs";
        string outputPath = demoPath + ".bak";

        [Test]
        public void copying_a_stream()
        {
            using (FileStream input = new FileStream(demoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                CopyFromTo(input, output);
            }
            File.ReadAllBytes(demoPath).ShouldAllBeEquivalentTo(File.ReadAllBytes(outputPath));
        }

        static void CopyFromTo(Stream input, Stream output, byte[] buffer = null)
        {
            if (input == null || !input.CanRead) throw new ArgumentException("Must be readable", nameof(input));
            if (output == null || !output.CanWrite) throw new ArgumentException("Must be writable", nameof(output));
            if (buffer == null) buffer = new Byte[4 * 1024];
            int lenRead;
            do
            {
                lenRead = input.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, lenRead);
            } while (lenRead == buffer.Length);
        }
    }
}

