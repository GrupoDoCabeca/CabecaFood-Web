using Domain.DTO;

namespace Domain.Entities
{
    public class DeliveryMan : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public double Salary { get; protected set; }
        public string PIS { get; protected set; }

        //Construtores
        public DeliveryMan()
        {

        }
        public DeliveryMan(string name, double salary, string pIS)
        {
            this.Name = name.FormatProps();
            this.PIS = pIS.FormatProps();
            this.Salary = salary;
        }
        public DeliveryMan(DeliveryManDTO deliveryMan)
        {
            this.Name = deliveryMan.Name.FormatProps();
            this.PIS = deliveryMan.PIS.FormatProps();
            this.Salary = deliveryMan.Salary;
        }


        //Metodos
        public void Update(string name, double salary, string pIS)
        {
            this.Name = name.FormatProps();
            this.PIS = pIS.FormatProps();
            this.Salary = salary;
        }
        public void Update(DeliveryManDTO deliveryMan)
        {
            this.Name = deliveryMan.Name.FormatProps();
            this.PIS = deliveryMan.PIS.FormatProps();
            this.Salary = deliveryMan.Salary;
        }
    }
}
