using System;
using System.Threading.Tasks;

namespace AsyncRecipe.Core
{
    public class AsyncExample
    {
        public async Task<int> UIExample()
        {
            await Task.Delay(1000);
            return 42;
        }
    }
}
