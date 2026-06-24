using Best_Practices.ModelBuilders;
using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Factories
{
    public class FordEscapeCreator : Creator
    {
        public override string ModelKey => "Escape";

        public override Vehicle Create()
        {
            var builder = new CarBuilder();
            return builder
                .SetBrand("Ford")
                .SetModel("Escape")
                .SetColor("Red")
                .Build();
        }
    }
}
