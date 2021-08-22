using TDocumentGeneration.Models;
using Xunit;

namespace TDocumentGeneration.Test
{
    public class GeneratorTest
    {
        private readonly Generator _generator;

        public GeneratorTest() => _generator = new Generator();
        

        [Fact]
        public void Test1()
        {
            // Given
            var data = new Data(new FileData(@"C:\Users\User\Desktop\test", "test.pdf", @"C: \Users\User\Desktop\test"));

            // When
            // _generator.Generate(data);
        }
    }
}
