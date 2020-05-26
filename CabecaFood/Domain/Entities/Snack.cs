using Domain.DTO;

namespace Domain.Entities
{
    public class Snack : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public string Description { get; protected set; }

        //Construtores
        public Snack()
        {

        }
        public Snack(string name, double price, string description)
        {
            this.Name = name.FormatProps();
            this.Description = description.FormatProps();
            this.Price = price;
        }
        public Snack(SnackDTO snack)
        {
            this.Name = snack.Name.FormatProps();
            this.Description = snack.Description.FormatProps();
            this.Price = snack.Price;
        }

        //Metodos
        public void Update(string name, double price, string description)
        {
            this.Name = name.FormatProps();
            this.Description = description.FormatProps();
            this.Price = price;
        }
        public void Update(SnackDTO snack)
        {
            this.Name = snack.Name.FormatProps();
            this.Description = snack.Description.FormatProps();
            this.Price = snack.Price;
        }
    }
}
