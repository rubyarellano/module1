using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module1
{
    internal class Program
    {
            public class DictionaryRepository<TKey, TValue> where TKey : IComparable<TKey>
        {
            private Dictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();

            public void Add(TKey id, TValue item)
            {
                if (_items.ContainsKey(id))
                    throw new ArgumentException("An item with the same key already exists.");
                _items[id] = item;
            }

            public TValue Get(TKey id)
            {
                if (!_items.ContainsKey(id))
                    throw new KeyNotFoundException("The key does not exist.");
                return _items[id];
            }

            public void Update(TKey id, TValue newItem)
            {
                if (!_items.ContainsKey(id))
                    throw new KeyNotFoundException("The key does not exist.");
                _items[id] = newItem;
            }

            public void Delete(TKey id)
            {
                
                if (!_items.ContainsKey(id))
                    throw new KeyNotFoundException("The key does not exist.");
                _items.Remove(id);
            }
        }

        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }

            public override string ToString()
            {
                return $"ProductId: {ProductId}, ProductName: {ProductName}";
            }
        }

        class program
        {
            static void Main(string[] args)
            {
                var productRepo = new DictionaryRepository<int, Product>();

                while (true)
                {
                    Console.WriteLine("\nChoose an operation:");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Retrieve Product");
                    Console.WriteLine("3. Update Product");
                    Console.WriteLine("4. Delete Product");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 5)
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                    }

                    if (choice == 5) break;

                    try
                    {
                        switch (choice)
                        {
                            case 1: // Add Product
                                Console.Write("Enter Product ID: ");
                                int addId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Product Name: ");
                                string addName = Console.ReadLine();
                                productRepo.Add(addId, new Product { ProductId = addId, ProductName = addName });
                                Console.WriteLine("Product added successfully.");
                                break;

                            case 2: // Retrieve Product
                                Console.Write("Enter Product ID to retrieve: ");
                                int getId = int.Parse(Console.ReadLine());
                                var product = productRepo.Get(getId);
                                Console.WriteLine("Retrieved: " + product);
                                break;

                            case 3: // Update Product
                                Console.Write("Enter Product ID to update: ");
                                int updateId = int.Parse(Console.ReadLine());
                                Console.Write("Enter new Product Name: ");
                                string updateName = Console.ReadLine();
                                productRepo.Update(updateId, new Product { ProductId = updateId, ProductName = updateName });
                                Console.WriteLine("Product updated successfully.");
                                break;

                            case 4: // Delete Product
                                Console.Write("Enter Product ID to delete: ");
                                int deleteId = int.Parse(Console.ReadLine());
                                productRepo.Delete(deleteId);
                                Console.WriteLine("Product deleted successfully.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
