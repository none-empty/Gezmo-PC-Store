using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Models;

public class MainModel
{
  public List<Product>AllProducts { get; set; } = new List<Product>(); 
  public List<Product>BestSeller { get; set; } = new List<Product>(); 
  public List<Product>MostRecent { get; set; } = new List<Product>();
}