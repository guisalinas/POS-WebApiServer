using POS_ApiServer.Services;

namespace POS_ApiServer.Utils
{
    public static class UtilsProducts
    {
        public async static Task<string> generateProductCode(IProductService productService, string prefix)
        {
            var numberCode = "";

            do
            {
               numberCode = GetRandomNumber();
            } while (await productService.ExistsByProductCodeAsync(numberCode));

            var productCode = $"{prefix}-{numberCode}";
            Console.WriteLine(productCode);
            return productCode;
        }


        private static string GetRandomNumber()
        {
            var random = new Random();
            var number = random.Next(1000, 9999);
            return number.ToString();
        }

    }
}
