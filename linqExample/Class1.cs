namespace linqExample
{
    class Class1
    {
        public static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category { CategoryId = 1,CategoryName="Bilgisayaer" },
                new Category { CategoryId = 2,CategoryName="Telefon" },
            };
            List<Product> products = new List<Product>
            {
             new Product { ProductId =1 ,CategoryId=1,ProductName="Acer laptop",QuantıtyPerUnit="32 gb ram", UnitPrice=17000,UnitsInStock=3},
             new Product { ProductId =2 ,CategoryId=1,ProductName="MSI laptop",QuantıtyPerUnit="32 gb ram", UnitPrice=15000,UnitsInStock=3},
             new Product { ProductId =3 ,CategoryId=1,ProductName="asus laptop",QuantıtyPerUnit="4 gb ram", UnitPrice=15000,UnitsInStock=1},
             new Product { ProductId =4 ,CategoryId=2,ProductName="samsung Teelfon",QuantıtyPerUnit="4 gb ram", UnitPrice=5000,UnitsInStock=1},
             new Product { ProductId =5 ,CategoryId=2,ProductName="Apple Teelfon",QuantıtyPerUnit="4 gb ram", UnitPrice=5000,UnitsInStock=1},
            };

            // Test(products);
            //AnyTest(products);
            //FindTest(products);
            // FindAllTest(products);
            //AscDescTest(products);

            //ClassicLinqTest(products);
            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductDto {CategoryName=c.CategoryName, ProductId=p.ProductId,ProductName=p.ProductName,UnitPrice=p.UnitPrice };
            foreach(var productDto in result)
            {
                Console.WriteLine(productDto.ProductName+ "  " + productDto.CategoryName);
            }

        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products
                         where p.CategoryId == 1
                         orderby p.UnitPrice > 6000 ascending, p.ProductId descending
                         select p;
            foreach (var product in result)
            {
                Console.WriteLine(product);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice).ThenBy(p => p.ProductName);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }
       

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("l"));
            //FindAll Liste döner --- Find nesne döner----- Any varmı yoku diye kontrol eder true yada false döner.
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 3);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any();
            var result1 = products.Any(p => p.ProductName == "Acer laptop");
            Console.WriteLine(result);
            Console.Write(result1);
        }

        private static void Test(List<Product> products)
        {
            Console.WriteLine("Algoritmik--------------------------");
            foreach (var product in products)
            {
                if (product.UnitPrice >= 5000 && product.UnitsInStock > 2)
                {
                    Console.WriteLine(product.ProductName);
                }

            }
            Console.WriteLine("Linq--------------------------");
            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 2);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        static List<Product> GetProducts(List<Product> products)
        {
            List<Product> filteredProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.UnitPrice >= 5000 && product.UnitsInStock > 2)
                {
                    filteredProducts.Add(product);
                }


            }
            return filteredProducts;

        }
        static List<Product> GetProductsLinq(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 2).ToList();
        }
        class ProductDto
        {
            public int ProductId { get; set; }
            public string CategoryName { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
        }
        class Product
        {
            public int ProductId { get; set; }
            public int CategoryId { get; set; }
            public string ProductName { get; set; }
            public string QuantıtyPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
        }
        class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
        }

    }
}